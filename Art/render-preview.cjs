// Requires Node.js, playwright and sharp. CHROME_PATH optionally selects the installed browser.
// Run from any directory: node Art/render-preview.cjs
const fs = require('node:fs');
const path = require('node:path');
const http = require('node:http');
const { chromium } = require('playwright');
const sharp = require('sharp');
const root = path.resolve(__dirname, '..');
const qa = path.join(__dirname, 'preview-qa');
const output = path.join(root, 'Mod/About/Preview.png');
const rgb = hex => hex.match(/[a-f0-9]{2}/gi).map(v => parseInt(v,16));
const luminance = c => c.map(v => {v/=255;return v<=.04045?v/12.92:((v+.055)/1.055)**2.4;}).reduce((s,v,i)=>s+v*[.2126,.7152,.0722][i],0);
const contrast = (a,b) => {const x=luminance(a),y=luminance(b);return (Math.max(x,y)+.05)/(Math.min(x,y)+.05);};
(async () => {
  fs.mkdirSync(qa, {recursive:true});
  const server = http.createServer((req,res) => {
    const file = path.resolve(root, '.' + decodeURIComponent(new URL(req.url,'http://localhost').pathname));
    if (!file.startsWith(root+path.sep)) {res.writeHead(403).end();return;}
    fs.readFile(file,(error,content)=>{if(error){res.writeHead(404).end();return;}res.setHeader('Content-Type',({'.html':'text/html','.json':'application/json','.xml':'application/xml','.png':'image/png'})[path.extname(file)]||'text/plain');res.end(content);});
  });
  await new Promise(resolve => server.listen(0,'127.0.0.1',resolve));
  let browser;
  try {
    browser = await chromium.launch({headless:true,executablePath:process.env.CHROME_PATH || 'C:/Program Files/Google/Chrome/Application/chrome.exe'});
    const page = await browser.newPage({viewport:{width:896,height:504},deviceScaleFactor:1});
    await page.goto(`http://127.0.0.1:${server.address().port}/Art/preview.html`);
    const parameters = await page.evaluate(() => window.previewReady);
    const selectors = ['h1','.title-link','.title-suffix','.tag','.summary','.version'];
    const boxes = await page.evaluate(selectors => Object.fromEntries(selectors.map(s=>{const e=document.querySelector(s),r=e.getBoundingClientRect(),c=getComputedStyle(e);return [s,{x:r.x,y:r.y,width:r.width,height:r.height,font:c.fontFamily,size:c.fontSize,weight:c.fontWeight,lineHeight:c.lineHeight,color:c.color}];})),selectors);
    const cdp = await page.context().newCDPSession(page);
    await cdp.send('DOM.enable'); await cdp.send('CSS.enable');
    const doc = await cdp.send('DOM.getDocument');
    const fonts = {};
    for (const selector of selectors) {
      const {nodeId} = await cdp.send('DOM.querySelector',{nodeId:doc.root.nodeId,selector});
      fonts[selector] = (await cdp.send('CSS.getPlatformFontsForNode',{nodeId})).fonts;
      if (!fonts[selector].length || fonts[selector].some(f=>!f.familyName.startsWith('Segoe UI'))) throw new Error('Unexpected font: '+JSON.stringify(fonts));
    }
    const lineRects = await page.evaluate(() => {
      return [...document.querySelectorAll('h1 > span')].flatMap(e => {
        const r=document.createRange();r.selectNodeContents(e);
        return [...r.getClientRects()].map(r=>({x:r.x,y:r.y,width:r.width,height:r.height,secondary:e.classList.contains('title-suffix')}));
      });
    });
    const titleLines = Math.round(boxes.h1.height/parseFloat(boxes.h1.lineHeight));
    if(titleLines>2 || titleLines<1)throw new Error('Title must occupy one or two lines');
    for(const selector of ['.title-link','.title-suffix']) {
      if(Math.abs(parseFloat(boxes[selector].size)/parseFloat(boxes.h1.size)-.65)>.001 || boxes[selector].weight!=='600')throw new Error('Incorrect reduced-word typography');
    }
    if(boxes['.title-link'].color!==boxes['.summary'].color || boxes.h1.color!==boxes['.summary'].color || boxes['.title-suffix'].color!==boxes['.tag'].color)throw new Error('Incorrect title ink hierarchy');
    for (const b of Object.values(boxes)) if(b.x<0||b.y<0||b.x+b.width>896||b.y+b.height>504)throw new Error('Text outside image');
    if(boxes.h1.x+boxes.h1.width>792)throw new Error('Title too close to version badge');
    const badgeFits = await page.evaluate(() => {
      const e=document.querySelector('.version'),w=e.offsetWidth,h=e.offsetHeight;
      return [-1,1].every(a=>[-1,1].every(b=>{const x=869+(a*w/2-b*h/2)/Math.sqrt(2),y=27+(a*w/2+b*h/2)/Math.sqrt(2);return x<=896&&y>=0&&x-y>=816;}));
    });
    if(!badgeFits)throw new Error('Version glyph box extends beyond badge');
    const capture = await page.screenshot({type:'png'});
    await sharp(capture).png({compressionLevel:9}).toFile(output);
    await sharp(capture).resize({width:268}).png().toFile(path.join(qa,'preview-268.png'));
    await page.addStyleTag({content:'.copy,.version { visibility:hidden !important; }'});
    const background = await page.screenshot({path:path.join(qa,'background.png')});
    const {data,info} = await sharp(background).removeAlpha().raw().toBuffer({resolveWithObject:true});
    const ratios = {};
    // All pixels in the text rectangles, not just four corners: conservative even between glyphs.
    for (const selector of ['h1','.title-suffix','.tag','.summary']) {
      const regions = selector==='h1'?lineRects.filter(r=>!r.secondary):selector==='.title-suffix'?lineRects.filter(r=>r.secondary):[boxes[selector]];
      const ink = rgb(['.tag','.title-suffix'].includes(selector)?parameters.palette.inkSecondary:parameters.palette.inkPrimary);
      let minimum=Infinity, location;
      for(const b of regions)for(let y=Math.floor(b.y);y<Math.ceil(b.y+b.height);y++)for(let x=Math.floor(b.x);x<Math.ceil(b.x+b.width);x++){
        const i=(y*info.width+x)*info.channels;
        const ratio=contrast(ink,[...data.subarray(i,i+3)]);
        if(ratio<minimum){minimum=ratio;location={x,y};}
      }
      ratios[selector]={minimum,location};
    }
    const i=(27*info.width+869)*info.channels;
    ratios['.version']={minimum:contrast(rgb(parameters.palette.badgeInk),[...data.subarray(i,i+3)]),location:{x:869,y:27}};
    const report={parameters,fonts,boxes,titleLines,badgeFits,contrast:ratios,bytes:fs.statSync(output).size,method:'Contrast on every background pixel in title word rectangles with their respective inks and tag/summary rectangles; opaque badge sampled at its center; shadows excluded.'};
    fs.writeFileSync(path.join(qa,'report.json'),JSON.stringify(report,null,2)+'\n');
    console.log(JSON.stringify({fonts, titleLines:report.titleLines, contrast:ratios, bytes:report.bytes},null,2));
    if(Object.values(ratios).some(r=>r.minimum<4.5))throw new Error('Contrast below 4.5:1');
    if(report.bytes>=900000)throw new Error('Preview must be below 900 kB');
  } finally { if(browser) await browser.close(); await new Promise(resolve=>server.close(resolve)); }
})().catch(e=>{console.error(e);process.exitCode=1;});

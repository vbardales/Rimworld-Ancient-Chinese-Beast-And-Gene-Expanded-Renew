// Composites this mod's ModIcon (cut out from its near-black square background by a border flood-fill,
// never a global colour-distance threshold) onto a corner of the delivered Preview.png, rotated, its
// edge touching the image edge. STYLE_RIMWORLD.md, "Le ModIcon détouré sur la vitrine" (2026-09-29):
// the corner is on the same side as the text block (left text -> left icon, right text -> right icon),
// the opposite vertical corner; left = +15 deg, right = -15 deg. No intermediate file is kept in Art/.
//
// Run from Art/: node compose-preview.cjs <left|right> <top|bottom> [sideBeforeRotation=150]
const sharp = require('sharp');

const CANVAS_W = 896, CANVAS_H = 504;
const side = (process.argv[2] || 'left').toLowerCase();       // must match the text block's side
const vpos = (process.argv[3] || 'top').toLowerCase();        // opposite corner from the text block
const iconSide = Number(process.argv[4] || 150);
const angle = side === 'left' ? 15 : -15;

async function cutout(file) {
  const img = sharp(file).ensureAlpha();
  const { data, info } = await img.raw().toBuffer({ resolveWithObject: true });
  const { width, height, channels } = info;
  const at = (x, y) => { const i = (y * width + x) * channels; return [data[i], data[i + 1], data[i + 2]]; };
  const corners = [at(0, 0), at(width - 1, 0), at(0, height - 1), at(width - 1, height - 1)];
  const bg = corners[0];
  for (const c of corners)
    if (Math.abs(c[0] - bg[0]) > 5 || Math.abs(c[1] - bg[1]) > 5 || Math.abs(c[2] - bg[2]) > 5)
      throw new Error(`corners disagree on background colour: ${corners.map(c => c.join(',')).join(' | ')}`);
  const close = (x, y) => { const [r, g, b] = at(x, y); return Math.abs(r - bg[0]) <= 30 && Math.abs(g - bg[1]) <= 30 && Math.abs(b - bg[2]) <= 30; };
  const visited = new Uint8Array(width * height);
  const stack = [];
  for (let x = 0; x < width; x++) { stack.push([x, 0], [x, height - 1]); }
  for (let y = 0; y < height; y++) { stack.push([0, y], [width - 1, y]); }
  while (stack.length) {
    const [x, y] = stack.pop();
    if (x < 0 || y < 0 || x >= width || y >= height) continue;
    const idx = y * width + x;
    if (visited[idx]) continue;
    if (!close(x, y)) continue;
    visited[idx] = 1;
    data[idx * channels + 3] = 0;
    stack.push([x + 1, y], [x - 1, y], [x, y + 1], [x, y - 1]);
  }
  let minX = width, minY = height, maxX = -1, maxY = -1;
  for (let y = 0; y < height; y++)
    for (let x = 0; x < width; x++)
      if (data[(y * width + x) * channels + 3] > 0) {
        if (x < minX) minX = x; if (x > maxX) maxX = x;
        if (y < minY) minY = y; if (y > maxY) maxY = y;
      }
  return sharp(data, { raw: { width, height, channels } }).extract({ left: minX, top: minY, width: maxX - minX + 1, height: maxY - minY + 1 });
}

(async () => {
  const cut = await cutout('ModIcon-source.png').then(p => p.png().toBuffer());

  // Checkerboard proof, kept only as a QA artefact under preview-qa/, not in Art/ itself.
  const checker = Buffer.from(
    `<svg width="400" height="400"><defs><pattern id="c" width="40" height="40" patternUnits="userSpaceOnUse">` +
    `<rect width="40" height="40" fill="#bbb"/><rect width="20" height="20" fill="#eee"/><rect x="20" y="20" width="20" height="20" fill="#eee"/></pattern></defs>` +
    `<rect width="400" height="400" fill="url(#c)"/></svg>`
  );
  const cutMeta = await sharp(cut).metadata();
  await sharp(checker)
    .resize(Math.max(cutMeta.width, 400), Math.max(cutMeta.height, 400))
    .composite([{ input: cut, gravity: 'center' }])
    .png()
    .toFile('preview-qa/modicon-checker.png');

  const resized = await sharp(cut).resize(iconSide, iconSide, { fit: 'inside' }).png().toBuffer();
  const rotated = await sharp(resized).rotate(angle, { background: { r: 0, g: 0, b: 0, alpha: 0 } }).png().toBuffer();
  const rMeta = await sharp(rotated).metadata();

  const left = side === 'left' ? 0 : CANVAS_W - rMeta.width;
  const top = vpos === 'top' ? 0 : CANVAS_H - rMeta.height;

  const base = await sharp('../Mod/About/Preview.png').toBuffer();
  await sharp(base)
    .composite([{ input: rotated, left, top }])
    .png()
    .toFile('../Mod/About/Preview.png');
  console.log(`icon ${side}-${vpos} angle=${angle} side=${iconSide} rotated=${rMeta.width}x${rMeta.height} pos=(${left},${top})`);
})();

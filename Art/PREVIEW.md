# Preview composition

`Preview.png` is the illustration without text, copied losslessly from the existing
`Preview-untitled.png`. No new illustration was generated and the original files remain intact.
`Preview-unofficial-source.png` is an older **lettered** version and must not be used as a
background. The current delivered image is `../Mod/About/Preview.png`.

Composition follows `../../STYLE_RIMWORLD.md` in the parent mod collection. `preview.html` loads `preview-palette.json` as its
only palette and `preview-layout.json` for geometry, summary, veil settings and text position. This
composition uses the calm lower-right ground (`textPosition: bottom-right`) so its title and summary
do not cover the beasts in the upper half. It reads the
name, suffix and highest stable supported version from the delivered `About.xml` at render time.
All text is rasterized directly at 896 x 504, not scaled down from a larger image.
Title hierarchy is configured by `titleConnectors` and `titleAffixes`: direct spans render
`And` and `Renew` at 65% of 46 px, retaining weight 600. The connector retains the primary ink;
the suffix uses the secondary ink. The separate status tag is not part of that hierarchy.

Run `node Art/render-preview.cjs` from the repository, with Node packages `playwright` and `sharp`
available and Chrome installed. Set `CHROME_PATH` for a non-default browser installation.
The renderer uses a temporary localhost server, waits for the illustration and
`document.fonts.ready`, verifies the actual Segoe UI faces through Chrome's font inspection API,
and captures the image. It stops on failed contrast, excessive file size or invalid geometry.
`title.ps1` is now a compatibility entry point to this HTML renderer.

`preview-qa/report.json` records the rendered typography, bounds, version and contrast results.
`preview-qa/background.png` is a separate capture with text and its shadows hidden, retaining
the veil and badge. Contrast is checked against every pixel in each text region, including
the four corners, using WCAG relative luminance; the badge uses its opaque rendered background.
`preview-qa/preview-268.png` is the thumbnail used for visual inspection.

Palette rationale: the veil is sampled from the calm lower-right earth. The red firecrackers
are amplified for the vivid accent, clearly separate from the dominant ochre family. The secondary ink
comes from the dominant ochre family of earth and fur, lightened while retaining its warmth.
The final colour values live only in the palette JSON; `STATUS.md` records the checks.

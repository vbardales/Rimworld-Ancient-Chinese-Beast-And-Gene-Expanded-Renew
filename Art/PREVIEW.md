# Preview composition

`Preview.png` is the illustration without text, copied losslessly from the existing
`Preview-untitled.png`. No new illustration was generated and the original files remain intact.
`Preview-unofficial-source.png` is an older **lettered** version and must not be used as a
background. The current delivered image is `../Mod/About/Preview.png`.

Composition follows `../../STYLE_RIMWORLD.md` in the parent mod collection. `preview.html` loads `preview-palette.json` as its
only palette and `preview-layout.json` for geometry, summary, veil settings and text position. This
composition puts the copy in the upper-left (`textPosition: top-left`), on the dark, empty ground, so that the
winged beast, the wind sweep and the three red firecrackers are all in view. The lower-right placement this
replaced covered the firecrackers, which are the image's one vivid accent, and its veil dimmed the beast.
`summaryWidth` (optional, default 430) keeps the summary from running into the beast's head. It reads the
name, suffix and highest stable supported version from the delivered `About.xml` at render time.
All text is rasterized directly at 896 x 504, not scaled down from a larger image.
Title hierarchy is configured by `titleConnectors` and `titleAffixes`: direct spans render
`And` and `Renew` at 65% of the title size (34 px, so 22 px), retaining weight 600. The connector retains the primary ink;
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

Palette rationale: the veil is sampled from shadowed earth and anchored at the text's corner. The red firecrackers
are amplified for the vivid accent, clearly separate from the dominant ochre family. The secondary ink
comes from the dominant ochre family of earth and fur, lightened while retaining its warmth.
The final colour values live only in the palette JSON; `STATUS.md` records the checks.

## Regravure of 2026-09-25, to the charter of that day

`STYLE_RIMWORLD.md` gave the engraved text measures the first composition (2026-09-24) predated: a title of 46 px by
default and 34 to 62 px at the outside, a 50 px left margin and a 54 px top margin, a 430 px summary. This composition takes
what the illustration allows of them: **title 34 px, left margin 50 px, two lines** (the charter's minimum size, and the
most this long name lets stand clear of the beast), the rule, the `(unofficial)` tag, the version badge and the sizes of the
tag (24 px), summary (21 px) and rule (58 x 3 px) as written. Two values still differ, on purpose:

- **Top margin 24 px, not 54.** At 54 the second title line falls on the beast's muzzle (rendered and looked at). The
  charter's own test is that no text hides the subject.
- **Summary width 330 px, not 430.** At 430 the summary runs into the paw; the renderer keeps `summaryWidth` optional for this.

A title at 46 px would need a line of about 500 px and cannot stay clear of the beast in the upper left; the lower right
was rendered too and covers the three red firecrackers, the image's one vivid accent, so it was dropped again.
The veil holds its opacity a little further (`veilHoldPercent` 34, `veilFadePercent` 56) because "Renew", in the secondary
ink, read 4.39:1 where the beast's fur begins; it now reads 5.17:1 and every text region is above 4.5:1. The image is
896 x 504, 734,072 bytes, Segoe UI throughout (checked by Chrome's font API).

## Regravure of 2026-09-27, moved to the bottom-left corner

The owner flagged that the upper-left composition above did not sit in the illustration's largest empty area: it
passed every contrast check, but "Renew" still visibly touched the beast's ear. Two alternatives were rendered and
compared before touching anything: `bottom-right` (the collection's only other preset) put the title and summary
squarely over the three red firecrackers, the image's one accent, and over the front paw; forcing a different title
wrap (moving "And" to the first line, so "Renew" would clear the ear) moved the collision onto the eye instead, the
illustration's one focal point. Neither improved on the original.

The illustration's actual largest calm ground is below the beast and its paw, left of the firecrackers: the dust
swirl and bare dirt spanning roughly x:0-420, y:280-504. Neither preset anchors there, so `Art/preview.html` gained
a third, mod-local `bottom-left` position (`left`/`bottom` anchored, same as `bottom-right`'s pattern mirrored to the
left edge; the shared collection guide is not touched, only this mod's own copy). `preview-layout.json` now carries
`"textPosition": "bottom-left"` with the same `textLeft`/`textBottom` margins (50 / 18 px) the charter gives its two
presets, unchanged `titleWidth` (372) and `summaryWidth` (330). The veil's radial gradient now anchors at
`bottom left` instead of `top left`, following the text block as the palette rationale requires.

Result: no text touches the beast, its paw, its eye or the firecrackers at any point; every contrast minimum rose
(the lowest is now 5.03:1, the version badge, unchanged by this move). `Art/Preview.ico` was regenerated from the
new `Mod/About/Preview.png` the same way as before (six sizes, transparent top/bottom margins keeping the 16:9
frame). The image is 896 x 504, 736,202 bytes, Segoe UI throughout.
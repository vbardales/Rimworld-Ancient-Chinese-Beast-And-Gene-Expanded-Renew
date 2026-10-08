# Preview

The committed Preview sources are:

- `Preview-source.png`: final text-free background at its rendering crop;
- `echo.png`: final hand-authored line art, consumed without cleanup or restroking;
- `ModIcon-source.png`: final transparent high-resolution badge source;
- `Preview.config.json`: copy, typography, layout and palette.

From the repository root, regenerate with:

```powershell
node ..\scripts\Render-Preview.cjs
```

The shared renderer writes `Mod/About/Preview.png`, copies it byte-for-byte to
`Art/Gallery/0-preview.png`, and regenerates `Art/Preview.ico` and
`Art/ModIcon.ico`. Temporary HTML and QA evidence live under ignored
`Art/.render/`.

The accepted layout uses a bottom-left panel, a bottom-right ModIcon, a mirrored
red line-art echo, and `Renew (unofficial)` together after `Expanded` on the
third title line. The renderer must not retouch `echo.png`.

Historical source variants and superseded local renderers remain recoverable
from Git history rather than as active files in `Art/`.

# Compatibility entry point. All preview text is now rendered by HTML/CSS.
# Requires Node.js, playwright, sharp and Chrome; see Art/PREVIEW.md.
$ErrorActionPreference = 'Stop'
& node (Join-Path $PSScriptRoot 'render-preview.cjs')
if ($LASTEXITCODE -ne 0) { throw "Preview rendering failed (exit $LASTEXITCODE)." }

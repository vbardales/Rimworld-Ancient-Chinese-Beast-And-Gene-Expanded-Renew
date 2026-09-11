# Draws the mod's title into the empty upper-left of the showcase image.
# Letters are laid out one at a time so the tracking can be set, and each is stroked dark before
# it is filled, so a line holds even where it crosses the lit dirt rather than the dark corner.
param([string]$In, [string]$Out)

Add-Type -AssemblyName System.Drawing

$img = New-Object System.Drawing.Bitmap($In)
$bmp = New-Object System.Drawing.Bitmap($img.Width, $img.Height, [System.Drawing.Imaging.PixelFormat]::Format24bppRgb)
$g   = [System.Drawing.Graphics]::FromImage($bmp)
$g.DrawImage($img, 0, 0, $img.Width, $img.Height)
$g.SmoothingMode     = 'AntiAlias'
$g.TextRenderingHint = 'AntiAliasGridFit'

$cream = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(255, 244, 233, 208))
$amber = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(255, 228, 172,  80))
$fam   = New-Object System.Drawing.FontFamily 'Cambria'
$fmt   = [System.Drawing.StringFormat]::GenericTypographic
$bold  = [int][System.Drawing.FontStyle]::Bold

# A soft dark halo under the whole block, so the cream never sits directly on a pale patch of dirt.
function Halo([single]$x, [single]$y, [single]$w, [single]$h) {
    $path = New-Object System.Drawing.Drawing2D.GraphicsPath
    $path.AddEllipse($x, $y, $w, $h)
    $br = New-Object System.Drawing.Drawing2D.PathGradientBrush($path)
    $br.CenterColor = [System.Drawing.Color]::FromArgb(150, 20, 16, 12)
    $br.SurroundColors = @([System.Drawing.Color]::FromArgb(0, 20, 16, 12))
    $g.FillPath($br, $path)
    $br.Dispose(); $path.Dispose()
}

# Returns the width drawn. A space gets extra room: GenericTypographic measures it narrowly, and
# at this tracking two words otherwise run together - ANCIENTCHINESE in the first attempt.
function Line([string]$text, [single]$size, [single]$x, [single]$y, [single]$track, $brush, [single]$stroke) {
    $pen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(240, 24, 18, 14)), $stroke
    $pen.LineJoin = 'Round'
    $font = New-Object System.Drawing.Font($fam, $size, [System.Drawing.FontStyle]::Bold)
    $cur = $x
    foreach ($ch in $text.ToCharArray()) {
        if ($ch -eq ' ') { $cur += $size * 0.34 + $track; continue }
        $p = New-Object System.Drawing.Drawing2D.GraphicsPath
        $p.AddString([string]$ch, $fam, $bold, $size, (New-Object System.Drawing.PointF($cur, $y)), $fmt)
        $g.DrawPath($pen, $p)
        $g.FillPath($brush, $p)
        $cur += $g.MeasureString([string]$ch, $font, [System.Drawing.PointF]::Empty, $fmt).Width + $track
        $p.Dispose()
    }
    $font.Dispose(); $pen.Dispose()
    return $cur - $x - $track
}

Halo -40 -60 620 340

$w1 = Line 'ANCIENT CHINESE'   36 42  38 2.0 $cream 4.5
$w2 = Line 'BEAST'             74 40  76 3.0 $cream 6.0
$w3 = Line 'AND GENE EXPANDED' 22 44 170 2.6 $amber 3.8
$w4 = Line 'RENEW'             22 44 204 2.6 $amber 3.8

"largeurs : $([math]::Round($w1)) / $([math]::Round($w2)) / $([math]::Round($w3)) / $([math]::Round($w4)) px"

$g.Dispose()
$bmp.Save($Out, [System.Drawing.Imaging.ImageFormat]::Png)
$bmp.Dispose(); $img.Dispose()
"ecrit : $Out"

using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class Graphic_Animation : Graphic_Collection
{
	public override Material MatSingle => subGraphics[0].MatSingle;

	public override void DrawWorker(Vector3 loc, Rot4 rot, ThingDef thingDef, Thing thing, float extraRotation)
	{
		Graphic graphic = ((!(thing is IAnimationThing animationThing)) ? subGraphics[0] : subGraphics[animationThing.Index]);
		graphic.DrawWorker(loc, rot, thingDef, thing, extraRotation);
	}
}

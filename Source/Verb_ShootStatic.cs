using Verse;

namespace AncientChineseBeast;

public class Verb_ShootStatic : Verb_LaunchProjectileStatic
{
	protected override int ShotsPerBurst => verbProps.burstShotCount;
}

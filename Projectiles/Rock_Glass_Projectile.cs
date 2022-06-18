using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassCannonClass.Projectiles
{
    internal class Rock_Glass_Projectile : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.arrow = true;
			Projectile.penetrate = 1;
			Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
			AIType = ProjectileID.WoodenArrowFriendly;
		}
	}
}

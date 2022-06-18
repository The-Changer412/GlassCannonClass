using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassCannonClass.Projectiles
{
    internal class GlassProjectile : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glass Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.arrow = true;
			Projectile.penetrate = 3;
			Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
			AIType = ProjectileID.WoodenArrowFriendly;
		}
	}
}

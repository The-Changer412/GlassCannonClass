using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassCannonClass.Projectiles
{
    internal class Glass_Shard : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.arrow = true;
			Projectile.penetrate = 5;
			Projectile.aiStyle = ProjectileID.Bullet;
			AIType = ProjectileID.Bullet;
		}
	}
}

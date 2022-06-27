using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassCannonClass.Projectiles
{
    internal class Musket_Glass_Projectile : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.aiStyle = ProjectileID.Bullet;
			AIType = ProjectileID.Bullet;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.Kill();
			return true;
        }
    }
}

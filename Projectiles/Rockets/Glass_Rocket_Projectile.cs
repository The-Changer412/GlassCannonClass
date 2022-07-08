using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace GlassCannonClass.Projectiles.Rockets
{
    internal class Glass_Rocket_1_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.arrow = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = ProjectileID.RocketI;
            AIType = ProjectileID.RocketI;
        }

        public override void PostAI()
        {
            Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            base.PostAI();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ProjectileID.Explosives, 220, 20);
            base.OnHitNPC(target, damage, knockback, crit);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ProjectileID.Explosives, 220, 20);
            base.OnHitPlayer(target, damage, crit);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ProjectileID.Explosives, 220, 20);
            base.OnHitPvp(target, damage, crit);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ProjectileID.Explosives, 220, 20);
            return base.OnTileCollide(oldVelocity);
        }
    }
}

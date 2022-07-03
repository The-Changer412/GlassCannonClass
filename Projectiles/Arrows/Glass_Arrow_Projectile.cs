using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassCannonClass.Projectiles.Arrows
{
    internal class Glass_Arrow_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.arrow = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
    }

    internal class Cursed_Flame_Glass_Arrow_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.arrow = true;
            Projectile.penetrate = 5;
            Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 7* 60);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }

    internal class Ichor_Glass_Arrow_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.arrow = true;
            Projectile.penetrate = 5;
            Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 10 * 60);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}

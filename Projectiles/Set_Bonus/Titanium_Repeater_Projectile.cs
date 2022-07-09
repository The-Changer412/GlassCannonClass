using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace GlassCannonClass.Projectiles.Set_Bonus
{
    internal class Titanium_Repeater_Projectile : ModProjectile
    {

        //set the sprite for the projectile
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            //set the stats for it
            Projectile.netImportant = true;
            Projectile.width = 52;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;

            //set the origin offset of the sprite
            DrawOriginOffsetX = -25;
            DrawOriginOffsetY = -4;
        }

        public override void AI()
        {
            //check if the player is dead and if the set bonus is active. if so, the constanly move and hover. if not, then kill it.
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.GetModPlayer<GlassPlayer>().HMT3SetBonus)
            {
                if (player.GetModPlayer<GlassPlayer>().LuminiteSetBonus)
                {
                    Projectile.position = player.position + new Vector2(4, -60);
                }
                else
                {
                    Projectile.position = player.position + new Vector2(4, -35);
                }
                Projectile.rotation = MathF.Atan2(Main.MouseWorld.Y - player.position.Y, Main.MouseWorld.X - player.position.X);

                //make the sprite flip correctly based on the rotation
                if (Projectile.rotation < 1.60 && Projectile.rotation > -1.55)

                {
                    Projectile.frame = 0;
                }
                else if (Projectile.rotation < -1.55 && Projectile.rotation > -3.14)

                {
                    Projectile.frame = 1;
                }
            }
            else
            {
                Projectile.Kill();
            }
        }
    }
}

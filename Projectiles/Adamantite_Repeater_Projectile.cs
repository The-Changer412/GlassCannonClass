using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace GlassCannonClass.Projectiles
{
	internal class Adamantite_Repeater_Projectile : ModProjectile
	{

		//set the name for the projectile
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Adamanantite Repeater Projectile");
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
				Projectile.position = player.position + new Vector2(4, -35);
				Projectile.rotation = MathF.Atan2((Main.MouseWorld.Y - player.position.Y), (Main.MouseWorld.X - player.position.X));
			}
			else
			{
				Projectile.Kill();
			}
        }
    }
}

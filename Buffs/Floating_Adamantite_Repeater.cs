using Terraria;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Set_Bonus;

namespace GlassCannonClass.Buffs
{
    internal class Floating_Adamantite_Repeater : ModBuff
    {
		//make the buff not save and dont show any time.
		public override void SetStaticDefaults()
		{
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		//reset the buff time if there is a floating repeater
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Adamantite_Repeater_Projectile>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
                buffIndex--;
            }
		}
	}
}

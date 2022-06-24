using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles;
using System.Collections.Generic;

namespace GlassCannonClass
{
	public class GlassCannonClass : Mod
	{

	}

	public class ExampleGlobalNPC : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Merchant)
			{
				//make the Merchant sell glass for one copper
				shop.item[nextSlot].SetDefaults(ItemID.Glass);
				shop.item[nextSlot].shopCustomPrice = Item.sellPrice(0, 0, 0, 1);
				nextSlot++;
			}
		}
	}

	public class GlassPlayer : ModPlayer
    {
		public bool EvilSetBonus = false;
		public bool HMT3SetBonus = false;
		
		public override void OnHitAnything(float x, float y, Entity victim)
        {
			//make the set bonus for the evil set bonus, where it has a 20% chance to fire an extra arrow when hitting an enemy
			if (EvilSetBonus && Main.rand.Next(1, 5) == 1)
            {
				int pro = Projectile.NewProjectile(Player.GetSource_OnHit(victim), Player.position, victim.DirectionFrom(Player.position) * 30, ModContent.ProjectileType<Glass_Shard>(), 10, 2f, Player.whoAmI);
				Projectile.
			}
			if (HMT3SetBonus)
            {
				
            }
            base.OnHitAnything(x, y, victim);
        }

        public override void ResetEffects()
        {
            EvilSetBonus = false;
			HMT3SetBonus = false;
	}
    }

	public class GlassDamage : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			//make it inherinat nothing from othe classes
			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.Full;

			return StatInheritanceData.None;
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			//make this class not activate any effects from the other classes
			return false;
		}

		public override void SetDefaultStats(Player player)
		{
			//set the default bonus stats of the items
			player.GetCritChance<GlassDamage>() += 4;
			player.GetArmorPenetration<GlassDamage>() += 5;
		}

		//use standard critical strike calculations.
		public override bool UseStandardCritCalcs => true;
	}
}
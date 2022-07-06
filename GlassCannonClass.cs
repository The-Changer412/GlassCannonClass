using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Other_Ammo;
using GlassCannonClass.Projectiles.Set_Bonus;

namespace GlassCannonClass
{
    public class GlassCannonClass : Mod
	{

	}

	public class ModifyGlobalProjectile: GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(projectile, target, damage, knockback, crit);
        }
    }

	public class ModifyGlobalNPC : GlobalNPC
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
		public bool HMT3SetBonusAdamantite = false;
		public bool HMT3SetBonusTitanium = false;
		public bool ChlorophyteSetBonus = false;
		public int ChlorophyteSetBonusCount = 0;

		//spawn in the set bonus for hardmode tier 3 glass armor
		public override void PostUpdate()
        {
			if (HMT3SetBonus)
			{
				//check if the set bonus have been spawned in before
				bool HMT3SetBonusHaveSpawned = false;
				foreach (Projectile pro in Main.projectile)
				{
					if ((pro.Name == "Adamanantite Repeater Projectile" || pro.Name == "Titamium Repeater Projectile") && pro.owner == Player.whoAmI)
					{
						HMT3SetBonusHaveSpawned = true;
					}
				}
				//spawn in the floating repeater based on the armor set
				if (HMT3SetBonusHaveSpawned == false)
                {
					if (HMT3SetBonusAdamantite)
                    {
						Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, Vector2.Zero, ModContent.ProjectileType<Adamantite_Repeater_Projectile>(), 0, 0f, Player.whoAmI);
					}
					else if (HMT3SetBonusTitanium)
                    {
						Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, Vector2.Zero, ModContent.ProjectileType<Titanium_Repeater_Projectile>(), 0, 0f, Player.whoAmI);
					}
				}
			}
		}

        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			//if the player have a floating repeater, then make the repeater shoot hellfire arrow when the player shoot
			foreach (Projectile pro in Main.projectile)
			{
				if ((pro.Name == "Adamanantite Repeater Projectile" || pro.Name == "Titamium Repeater Projectile") && pro.owner == Player.whoAmI)
				{
					Projectile.NewProjectile(Player.GetSource_NaturalSpawn(), Player.position + new Vector2(4, -30), velocity * 30, ProjectileID.HellfireArrow, 82, 2f, Player.whoAmI);
				}
			}
			return base.Shoot(item, source, position, velocity, type, damage, knockback);

        }


        public override void OnHitAnything(float x, float y, Entity victim)
        {
			//make the set bonus for the evil set bonus, where it has a 20% chance to fire an extra arrow when hitting an enemy
			if (EvilSetBonus && Main.rand.Next(1, 5) == 1)
            {
				Projectile.NewProjectile(Player.GetSource_OnHit(victim), Player.position, victim.DirectionFrom(Player.position) * 30, ModContent.ProjectileType<Glass_Shard>(), 10, 2f, Player.whoAmI);
			}

			if (ChlorophyteSetBonus)
            {
				if (ChlorophyteSetBonusCount >= 4)
                {
					Projectile.NewProjectile(Player.GetSource_FromThis(), victim.position, Vector2.Zero, ProjectileID.Explosives, 180, 20);
					ChlorophyteSetBonusCount = 0;

				}
				else
                {
					ChlorophyteSetBonusCount++;
				}
            }
            base.OnHitAnything(x, y, victim);
        }

        public override void ResetEffects()
        {
            EvilSetBonus = false;
			HMT3SetBonus = false;
			HMT3SetBonusAdamantite = false;
			HMT3SetBonusTitanium = false;
			ChlorophyteSetBonus = false;
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
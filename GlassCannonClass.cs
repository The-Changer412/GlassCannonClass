using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Other_Ammo;
using GlassCannonClass.Projectiles.Set_Bonus;
using GlassCannonClass.Buffs;
using System.Collections.Generic;

namespace GlassCannonClass
{
    public class GlassCannonClass : Mod
	{

	}

	//make a friendly version of golem's lazer
	public class ModifyGlobalProjectile : GlobalProjectile
	{
		public override void SetDefaults(Projectile projectile)
		{
			if (projectile.type == ProjectileID.EyeBeam && projectile.damage != 28)
			{
				projectile.timeLeft = 100;
				projectile.velocity *= 3;
			}
			base.SetDefaults(projectile);
		}

        public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
			if (projectile.type == ProjectileID.EyeBeam && projectile.damage != 28)
            {
                if (target.friendly)
                {
                    return false;
                }
                else if (target.CanBeChasedBy())
                {
                    return true;
                }
				else
                {
					return null;
                }
            }
			else
            {
				return null;
            }
        }

        public override bool CanHitPlayer(Projectile projectile, Player target)
        {
			if (projectile.type == ProjectileID.EyeBeam && projectile.damage != 28)
			{
				return false;
			}
			else
			{
				return true;
			}
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
		public bool BeetleSetBonus = false;

		public override void PostUpdate()
        {
			//spawn in the set bonus for hardmode tier 3 glass armor
			if (HMT3SetBonus)
			{
				//spawn in adamantite repeater if the player does not have the buff
				if (HMT3SetBonusAdamantite && !Player.HasBuff<Floating_Adamantite_Repeater>())
                {
					Player.AddBuff(ModContent.BuffType<Floating_Adamantite_Repeater>(), 2);
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, Vector2.Zero, ModContent.ProjectileType<Adamantite_Repeater_Projectile>(), 0, 0f, Player.whoAmI);
				}

				//spawn in adamantite repeater if the player does not have the buff
				if (HMT3SetBonusTitanium && !Player.HasBuff<Floating_Titanium_Repeater>())
				{
					Player.AddBuff(ModContent.BuffType<Floating_Titanium_Repeater>(), 2);
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, Vector2.Zero, ModContent.ProjectileType<Titanium_Repeater_Projectile>(), 0, 0f, Player.whoAmI);
				}
			}

			//spawn in the set bonus for beetle glass armor
			if (BeetleSetBonus && !Player.HasBuff<Golem_Head_Buff>())
			{
				Player.AddBuff(ModContent.BuffType<Golem_Head_Buff>(), 2);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, Vector2.Zero, ModContent.ProjectileType<Golem_Head_Projectile>(), 0, 0f, Player.whoAmI);
			}
		}

        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			//if the player have a floating repeater buff, then make the repeater shoot hellfire arrow when the player shoot
			if (Player.HasBuff<Floating_Adamantite_Repeater>() || Player.HasBuff<Floating_Titanium_Repeater>())
            {
				Projectile.NewProjectile(Player.GetSource_NaturalSpawn(), Player.position + new Vector2(4, -30), velocity * 30, ProjectileID.HellfireArrow, 82, 2f, Player.whoAmI);
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

			//make it to where if you have the set bonus for chlorophyte, then you will spawn in a explosion every 5 hits
			if (ChlorophyteSetBonus)
            {
				if (ChlorophyteSetBonusCount >= 4)
                {
					Projectile.NewProjectile(Player.GetSource_FromThis(), victim.position, Vector2.Zero, ProjectileID.Explosives, 230, 20);
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
			BeetleSetBonus = false;
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
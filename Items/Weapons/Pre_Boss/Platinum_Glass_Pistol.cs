﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace GlassCannonClass.Items.Weapons.Pre_Boss
{
    public class Platinum_Glass_Pistol : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 50;
            Item.width = 12;
            Item.height = 25;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = AmmoID.Bullet;
            Item.UseSound = SoundID.Item11;
            Item.DamageType = ModContent.GetInstance<GlassDamage>();
            Item.damage = 34;
            Item.crit += 8;
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.scale = 0.8f;
        }

        //make it where you can only use it with the full set of glass armor
        public override bool CanUseItem(Player player)
        {
            if (player.setBonus.Contains(Language.GetTextValue("Mods.GlassCannonClass.SetBonus.Phrase")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //make it have a 15 percent to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.15f;
        }

        //offset the slingshot so the player is holding it correctly
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-13, 0);
        }

        //make it craftable
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 6);
            recipe.AddIngredient(ItemID.Sandgun, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
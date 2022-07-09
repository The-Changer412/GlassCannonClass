﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GlassCannonClass.Items.Weapons.Endgame
{
    public class Luminite_Glass_Cannon : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 10;
            Item.width = 58;
            Item.height = 32;
            Item.useAmmo = 997;
            Item.shoot = 997;
            Item.UseSound = SoundID.Item5;
            Item.DamageType = ModContent.GetInstance<GlassDamage>();
            Item.damage = 200;
            Item.crit += 38;
            Item.shootSpeed = 62f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
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

        //make it have a 50 percent to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;
        }

        //make it craftable
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 30);
            recipe.AddIngredient(ItemID.LunarBar, 2);
            recipe.AddIngredient(ItemID.Celeb2, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
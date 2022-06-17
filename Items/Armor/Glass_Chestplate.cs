﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace GlassCannonClass.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    internal class Glass_Chestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //set the details for the item
            DisplayName.SetDefault("Glass Chestplate");
            Tooltip.SetDefault("I don't think glass is a good material to use for armor.");

            //make it where you only need one of them to dupe in in journey mode
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            //set the stats for the item
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.defense = 1;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 20)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}

﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace GlassCannonClass.Items.Armor.Pre_Boss
{
    [AutoloadEquip(EquipType.Legs)]
    internal class Platinum_Glass_Leggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //make it where you only need one of them to dupe in in journey mode
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            //set the stats for the item
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0,40, 0);
            Item.defense = 1;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 30)
                .AddIngredient(ItemID.GoldBar, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace GlassCannonClass.Items.Armor.Endgame
{
    [AutoloadEquip(EquipType.Legs)]
    internal class Luminite_Glass_Leggings : ModItem
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
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.defense = 7;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 30)
                .AddIngredient(ModContent.ItemType<Start.Glass_Leggings>())
                .AddRecipeGroup("GlassCannonClass:Pre_Boss_Leggings")
                .AddRecipeGroup("GlassCannonClass:Pre_HM_Leggings")
                .AddRecipeGroup("GlassCannonClass:Pre_Mechs_Leggings")
                .AddIngredient(ModContent.ItemType<Pre_Plantera.Chlorophyte_Glass_Leggings>())
                .AddIngredient(ModContent.ItemType<Pre_ML.Beetle_Glass_Leggings>())
                .AddIngredient(ItemID.LunarBar, 4)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            base.AddRecipes();
        }
    }
}

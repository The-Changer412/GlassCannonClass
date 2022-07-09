using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace GlassCannonClass.Items.Armor.Pre_Mechs
{
    [AutoloadEquip(EquipType.Body)]
    internal class Titamium_Glass_Chestplate : ModItem
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
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.defense = 4;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 30)
                .AddIngredient(ItemID.TitaniumBar, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            base.AddRecipes();
        }
    }
}

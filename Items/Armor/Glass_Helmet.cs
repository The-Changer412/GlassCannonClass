using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace GlassCannonClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    internal class Glass_Helmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //set the details for the item
            DisplayName.SetDefault("Glass Helmet");
            Tooltip.SetDefault("Don't Let the helmet break on your face.");

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
            Item.defense = 0;
            base.SetDefaults();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Items.Armor.Glass_Chestplate>() && legs.type == ModContent.ItemType<Items.Armor.Glass_Leggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You can now use glass weapons.\nWhy did you think that covering yourself in glass is a good idea?";
            
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}

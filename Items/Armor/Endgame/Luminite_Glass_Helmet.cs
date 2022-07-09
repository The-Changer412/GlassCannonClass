using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GlassCannonClass.Items.Armor.Endgame
{
    [AutoloadEquip(EquipType.Head)]
    internal class Luminite_Glass_Helmet : ModItem
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

        //check if the other two peices are the proper set for the set bonus
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Luminite_Glass_Chestplate>() && legs.type == ModContent.ItemType<Luminite_Glass_Leggings>();
        }

        //apply the set bonus
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.GlassCannonClass.SetBonus.Luminite_Glass");
            player.GetDamage(ModContent.GetInstance<GlassDamage>()) += 0.64f;
            player.GetCritChance(ModContent.GetInstance<GlassDamage>()) += 0.64f;
            player.GetModPlayer<GlassPlayer>().LuminiteSetBonus = true;
            player.GetModPlayer<GlassPlayer>().EvilSetBonus = true;
            player.GetModPlayer<GlassPlayer>().HMT3SetBonus = true;
            player.GetModPlayer<GlassPlayer>().HMT3SetBonusAdamantite = true;
            player.GetModPlayer<GlassPlayer>().HMT3SetBonusTitanium = true;
            player.GetModPlayer<GlassPlayer>().ChlorophyteSetBonus = true;
            player.GetModPlayer<GlassPlayer>().BeetleSetBonus = true;
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 30)
                .AddIngredient(ModContent.ItemType<Start.Glass_Helmet>())
                .AddRecipeGroup("GlassCannonClass:Pre_Boss_Helmet")
                .AddRecipeGroup("GlassCannonClass:Pre_HM_Helmet")
                .AddRecipeGroup("GlassCannonClass:Pre_Mechs_Helmet")
                .AddIngredient(ModContent.ItemType<Pre_Plantera.Chlorophyte_Glass_Helmet>())
                .AddIngredient(ModContent.ItemType<Pre_ML.Beetle_Glass_Helmet>())
                .AddIngredient(ItemID.LunarBar, 4)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            base.AddRecipes();
        }
    }
}

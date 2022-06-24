using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GlassCannonClass.Items.Armor.PreHM
{
    [AutoloadEquip(EquipType.Head)]
    internal class Crimtane_Helmet : ModItem
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
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0,80, 0);
            Item.defense = 3;
            base.SetDefaults();
        }

        //check if the other two peices are the proper set for the set bonus
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Crimtane_Chestplate>() && legs.type == ModContent.ItemType<Crimtane_Leggings>();
        }

        //apply the set bonus
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.GlassCannonClass.SetBonus.Demonite_Class");
            player.GetDamage(ModContent.GetInstance<GlassDamage>()) += 0.25f;
            player.GetCritChance(ModContent.GetInstance<GlassDamage>()) += 0.20f;
            player.GetModPlayer<GlassPlayer>().EvilSetBonus = true;
        }

        public override void AddRecipes()
        {
            //set the crafting recipe for the item
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 30)
                .AddIngredient(ItemID.CrimtaneBar, 8)
                .AddIngredient(ItemID.TissueSample, 4)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}

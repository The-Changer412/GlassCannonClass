using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GlassCannonClass.Items.Armor.PreMechs
{
    [AutoloadEquip(EquipType.Head)]
    internal class Titamium_Glass_Helmet : ModItem
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
            Item.value = Item.sellPrice(0, 1,20, 0);
            Item.defense = 4;
            base.SetDefaults();
        }

        //check if the other two peices are the proper set for the set bonus
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Titamium_Glass_Chestplate>() && legs.type == ModContent.ItemType<Titamium_Glass_Leggings>();
        }

        //apply the set bonus
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.GlassCannonClass.SetBonus.HMT3_Glass_Titamium");
            player.GetDamage(ModContent.GetInstance<GlassDamage>()) += 0.42f;
            player.GetCritChance(ModContent.GetInstance<GlassDamage>()) += 0.32f;
            player.GetModPlayer<GlassPlayer>().HMT3SetBonus = true;
            player.GetModPlayer<GlassPlayer>().HMT3SetBonusTitanium = true;
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

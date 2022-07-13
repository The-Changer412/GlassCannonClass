using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GlassCannonClass.Items.Weapons.Pre_Mechs
{
    public class Adamantite_Glass_Repeater : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 24;
            Item.width = 12;
            Item.height = 25;
            Item.useAmmo = 999;
            Item.shoot = 999;
            Item.UseSound = SoundID.Item5;
            Item.DamageType = ModContent.GetInstance<GlassDamage>();
            Item.damage = 125;
            Item.crit += 40;
            Item.shootSpeed = 50f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 1, 20, 0);
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

        //make it have a 20 percent to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.22f;
        }

        //make it craftable
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 30);
            recipe.AddIngredient(ItemID.AdamantiteBar, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}

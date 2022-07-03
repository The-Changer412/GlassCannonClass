using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Arrows;
using GlassCannonClass.Items.Ammo.Arrows;

namespace GlassCannonClass.Items.Weapons.Pre_HM
{
    public class Demonite_Glass_Bow : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 35;
            Item.width = 12;
            Item.height = 25;
            Item.useAmmo = 999;
            Item.shoot = 999;
            Item.UseSound = SoundID.Item5;
            Item.DamageType = ModContent.GetInstance<GlassDamage>();
            Item.damage = 52;
            Item.crit += 14;
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 0, 80, 0);
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
            return Main.rand.NextFloat() >= 0.20f;
        }

        //make it craftable
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 30);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddIngredient(ItemID.ShadowScale, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Items.Ammo;

namespace GlassCannonClass.Items.Weapons
{
    public class Slingshot : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 50;
            Item.width = 12;
            Item.height = 25;
            Item.shoot = ItemID.Glass;
            Item.useAmmo = ModContent.ItemType<GlassAmmo>();
            Item.UseSound = SoundID.Item5;
            Item.DamageType = ModContent.GetInstance<GlassDamage>();
            Item.damage = 16;
            Item.crit += 4;
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 0, 0, 1);
        }

        //make it where you can only use it with the full set of glass armor
        public override bool CanUseItem(Player player)
        {
            if (player.setBonus.Contains("You can now use glass weapons."))
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        //offset the slingshot so the player is holding it correctly
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        //make it craftable
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
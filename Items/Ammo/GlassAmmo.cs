using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles;

namespace GlassCannonClass.Items.Ammo
{
    internal class GlassAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses as ammo for weapons made out of glass.\nAmmo");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {

            base.SetDefaults();
            Item.width = 16;
            Item.height = 16;
            Item.ammo = ModContent.ItemType<GlassAmmo>();
            Item.shoot = ModContent.ProjectileType<GlassProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 1);
            recipe.Register();
        }
    }
}

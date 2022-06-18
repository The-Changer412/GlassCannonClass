using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles;

namespace GlassCannonClass.Items.Ammo
{
    internal class GlassAmmo : ModItem
    {
        public override void SetDefaults()
        {
            //set the stats for glass
            base.SetDefaults();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.ammo = ModContent.ItemType<GlassAmmo>();
            Item.shoot = ModContent.ProjectileType<GlassProjectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .Register();

            //craft glass from glass ammo for reverse crafting
            Mod.CreateRecipe(ItemID.Glass)
                .AddIngredient(ModContent.ItemType<GlassAmmo>(), 1)
                .Register();
        }
    }
}

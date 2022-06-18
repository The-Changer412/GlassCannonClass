using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles;

namespace GlassCannonClass.Items.Ammo
{
    internal class Arrow_Glass : ModItem
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
            Item.ammo = ModContent.ItemType<Arrow_Glass>();
            Item.shoot = ModContent.ProjectileType<Arrow_Glass_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.WoodenArrow, 1)
                .Register();
        }
    }
}

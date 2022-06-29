using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Arrows;

namespace GlassCannonClass.Items.Ammo
{
    internal class Glass_Arrow : ModItem
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
            Item.ammo = ModContent.ItemType<Glass_Arrow>();
            Item.shoot = ModContent.ProjectileType<Glass_Arrow_Projectile>();
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

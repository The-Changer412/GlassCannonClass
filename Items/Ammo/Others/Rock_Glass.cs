using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Other_Ammo;

namespace GlassCannonClass.Items.Ammo.Others
{
    internal class Rock_Glass : ModItem
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
            Item.ammo = ModContent.ItemType<Rock_Glass>();
            Item.shoot = ModContent.ProjectileType<Rock_Glass_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.StoneBlock, 1)
                .Register();
        }
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Arrows;

namespace GlassCannonClass.Items.Ammo.Arrows
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
            Item.ammo = 999;
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

    internal class Cursed_Flame_Glass_Arrow : ModItem
    {
        public override void SetDefaults()
        {
            //set the stats for glass
            base.SetDefaults();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 4f;
            Item.ammo = 999;
            Item.shoot = ModContent.ProjectileType<Cursed_Flame_Glass_Arrow_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.CursedArrow, 150)
                .Register();
        }
    }

    internal class Ichor_Glass_Arrow : ModItem
    {
        public override void SetDefaults()
        {
            //set the stats for glass
            base.SetDefaults();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 4f;
            Item.ammo = 999;
            Item.shoot = ModContent.ProjectileType<Ichor_Glass_Arrow_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.IchorArrow, 150)
                .Register();
        }
    }
}

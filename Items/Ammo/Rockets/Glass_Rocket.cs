﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Rockets;

namespace GlassCannonClass.Items.Ammo.Rockets
{
    internal class Glass_Rocket_1 : ModItem
    {
        public override void SetDefaults()
        {
            //set the stats for glass 
            base.SetDefaults();
            Item.width = 18;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.ammo = 997;
            Item.shoot = ModContent.ProjectileType<Glass_Rocket_1_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe(100)
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.RocketI, 100)
                .Register();
        }
    }
}

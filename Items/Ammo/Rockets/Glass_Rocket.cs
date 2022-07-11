using Terraria;
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
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 0, 0, 5);
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

    internal class Lumanite_Glass_Rocket : ModItem
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
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.shoot = ModContent.ProjectileType<Lumanite_Glass_Rocket_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft glass ammo from glass
            CreateRecipe(300)
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.LunarBar, 1)
                .AddIngredient(ItemID.RocketIII, 300)
                .Register();
        }
    }
}

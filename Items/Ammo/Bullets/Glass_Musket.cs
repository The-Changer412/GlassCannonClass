using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GlassCannonClass.Projectiles.Bullets;

namespace GlassCannonClass.Items.Ammo.Bullets
{
    internal class Glass_Musket : ModItem
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
            Item.ammo = 998;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.shoot = ModContent.ProjectileType<Glass_Musket_Projectile>();
        }

        public override void AddRecipes()
        {
            //craft musket glass ammo from glass
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 1)
                .AddIngredient(ItemID.MusketBall, 1)
                .Register();
        }
    }

    internal class Chlorophyte_Glass : ModItem
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
            Item.ammo = 998;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.shoot = ModContent.ProjectileType<Chlorophyte_Glass_Bullet>();
        }

        public override void AddRecipes()
        {
            //craft musket glass ammo from glass
            CreateRecipe(60)
                .AddIngredient(ModContent.ItemType<Glass_Musket>(), 60)
                .AddIngredient(ItemID.ChlorophyteBar, 1)
                .Register();
        }
    }
}

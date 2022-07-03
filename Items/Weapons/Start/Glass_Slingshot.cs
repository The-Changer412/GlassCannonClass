using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Other_Ammo;
using GlassCannonClass.Items.Ammo.Others;

namespace GlassCannonClass.Items.Weapons.Start
{
    public class Glass_Slingshot : ModItem
    {
        //set the stats for it
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 50;
            Item.width = 12;
            Item.height = 25;
            Item.useAmmo = ModContent.ItemType<Rock_Glass>();
            Item.shoot = ModContent.ProjectileType<Rock_Glass_Projectile>();
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
            if (player.setBonus.Contains(Language.GetTextValue("Mods.GlassCannonClass.SetBonus.Phrase")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //make it have a 10 percent to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.1f;
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
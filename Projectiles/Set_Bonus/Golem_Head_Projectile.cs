using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Bullets;

namespace GlassCannonClass.Projectiles.Set_Bonus
{
    internal class Golem_Head_Projectile : ModProjectile
    {
        public int MaxCooldown;
        public int cooldown;
        public override void SetDefaults()
        {
            //set the stats for it
            Projectile.netImportant = true;
            Projectile.width = 110;
            Projectile.height = 106;
            Projectile.scale = 0.45f;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            
            MaxCooldown = 40;
            cooldown = MaxCooldown;
        }

        public override void AI()
        {
            float SeeRange = 200f;
            Vector2 TargetPos = Projectile.position;
            bool FoundTarget = false;

            //check if the player is dead and if the set bonus is active. if so, the constanly move and hover. if not, then kill it.
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.GetModPlayer<GlassPlayer>().BeetleSetBonus)
            {
                Projectile.position = player.position + new Vector2(-46, -80);
            }
            else
            {
                Projectile.Kill();
            }

            //set the cooldown for the projectile
            if (cooldown >= 0)
            {
                cooldown--;
            }

            //find the closest enemy to shoot at
            if (!FoundTarget)
            {
                //iter between all npcs
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    //check if enemy
                    if (npc.CanBeChasedBy() || !Main.npc[i].townNPC || !Main.npc[i].friendly)
                    { 
                        float dis = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, TargetPos) > dis;
                        bool inRange = dis < SeeRange;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        bool closeThroughWall = dis < 100f;

                        if (((closest && inRange) || !FoundTarget) && (lineOfSight || closeThroughWall))
                        {
                            SeeRange = dis;
                            TargetPos = npc.Center;
                            FoundTarget = true;
                        }
                    }
                }
            }

            if (FoundTarget)
            {
                if (Main.myPlayer == Projectile.owner && cooldown <= 0)
                {
                    Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center, Projectile.DirectionTo(TargetPos) * 20, ProjectileID.EyeBeam, 300, 0f, Projectile.whoAmI);
                    cooldown = MaxCooldown;
                }
            }
        }
    }
}

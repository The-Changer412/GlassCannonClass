using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using GlassCannonClass.Projectiles.Bullets;

namespace GlassCannonClass.Projectiles.Set_Bonus
{
    internal class Golem_Head_Projectile : ModProjectile
    {

        public float distanceFromTarget;
        public Vector2 targetCenter;
        public bool foundTarget;
        public int maxCooldown;
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
            float distanceFromTarget = 700f;
            Vector2 targetCenter = Projectile.position;
            bool foundTarget = false;
            maxCooldown = 30;
            cooldown = maxCooldown;
        }


        public override void AI()
        {
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

            if(cooldown >= 0)
            {
                cooldown--;
            } else
            {
                cooldown = maxCooldown;
            }
            
        }

        public override void PostAI()
        {
            if (!foundTarget)
            {
                // This code is required either way, used for finding a target
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                        // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                        bool closeThroughWall = between < 100f;

                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            if (foundTarget)
            {
                System.Console.WriteLine("Communist Targeted");
                if (Main.myPlayer == Projectile.owner && cooldown <= 0)
                {
                    Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center + new Vector2(22, 50), Projectile.DirectionTo(targetCenter)*20, ProjectileID.EyeBeam, 150, 0f, Projectile.whoAmI);
                }
            }

            base.PostAI();
        }
    }
}

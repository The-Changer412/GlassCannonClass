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
            float SeeRange = 400f;
            Vector2 TargetPos = new Vector2(99999, 99999);
            bool FoundTarget = false;

            //check if the player is dead and if the set bonus is active. if so, the constanly move and hover. if not, then kill it.
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.GetModPlayer<GlassPlayer>().BeetleSetBonus)
            {
                if (player.GetModPlayer<GlassPlayer>().LuminiteSetBonus)
                {
                    Projectile.position = player.position + new Vector2(-46, -140);
                }
                else
                {
                    Projectile.position = player.position + new Vector2(-46, -70);
                }
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

            //iter between all npcs
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                //check if enemy is bad and not dead
                if (npc.CanBeChasedBy() && !npc.townNPC && !npc.friendly && npc.life > 0)
                {
                    //check if its not hiding behind a wall
                    if (Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                    {
                        //check if it is the closest enemy
                        if (Vector2.Distance(npc.Center, Projectile.Center) < SeeRange && Vector2.Distance(npc.Center, Projectile.Center) < Vector2.Distance(TargetPos, Projectile.Center))
                        {
                            TargetPos = npc.Center;
                        }
                    }
                }
            }

            //check if the target pos have been modified
            if (!Vector2.Equals(TargetPos, new Vector2(99999, 99999)))
            {
                FoundTarget = true;
            }


            //if found a target, then shoot at it when the cooldown is down and the player isnt dead
            if (FoundTarget)
            {
                if (cooldown <= 0)
                {
                    if (!player.dead)
                    {
                        if (player.GetModPlayer<GlassPlayer>().LuminiteSetBonus)
                        {
                            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center, Projectile.DirectionTo(TargetPos) * 20, ProjectileID.EyeBeam, 380, 2f, Projectile.whoAmI);
                        }
                        else
                        {
                            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center, Projectile.DirectionTo(TargetPos) * 20, ProjectileID.EyeBeam, 300, 2f, Projectile.whoAmI);
                        }
                    }
                    cooldown = MaxCooldown;
                    FoundTarget = false;
                    TargetPos = new Vector2(99999, 99999);
                }
            }
        }
    }
}

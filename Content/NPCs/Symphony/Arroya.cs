using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Items.Azolinth;
using TrelamiumRemastered.Content.Items.Symphony;
using TrelamiumRemastered.Content.Projectiles.Boss.Symphony;

namespace TrelamiumRemastered.Content.NPCs.Symphony
{
    [AutoloadBossHead]
    public class Arroya : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arroya, Siren of Tides");
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void FindFrame(int frameHeight)
        {
            int totalFrames = 4;
            NPC.frameCounter++; 
            if (NPC.frameCounter >= 60) 
            {
                NPC.frame.Y += frameHeight; 
                NPC.frameCounter = 0;
            }

            if (NPC.frame.Y >= frameHeight * totalFrames)
            {
                NPC.frame.Y = 0;
            }
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 1950;
            NPC.damage = 30;
            NPC.defense = 12;
            NPC.width = 112;
            NPC.height = 118;
            NPC.npcSlots = 5f;
            AnimationType = 48;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[ModContent.BuffType<SirensLament>()] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Ichor] = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            if (NPC.target < 0 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.20f;
                }
                else
                {
                    NPC.velocity.X = NPC.velocity.X - 0.20f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                NPC.rotation = NPC.velocity.X * 0.05f;
            }
            bool stage1 = (double)NPC.life >= (double)NPC.lifeMax * 0.5;
            float num1399 = 4f;
            float moveSpeed = 2.5f;
            NPC.TargetClosest(true);
            Vector2 desiredVelocity3 = Main.player[NPC.target].Center - NPC.Center + new Vector2(0f, -250f);
            float num1400 = desiredVelocity3.Length();
            if (NPC.Center.X < Main.player[NPC.target].Center.X - 2f)
            {
                NPC.direction = 1;
            }
            if (NPC.Center.X > Main.player[NPC.target].Center.X + 2f)
            {
                NPC.direction = -1;
            }
            NPC.spriteDirection = NPC.direction;
            if (num1400 < 20f)
            {
                desiredVelocity3 = NPC.velocity;
            }
            else if (num1400 < 40f)
            {
                desiredVelocity3.Normalize();
                desiredVelocity3 *= num1399 * 0.25f;
            }
            else if (num1400 < 80f)
            {
                desiredVelocity3.Normalize();
                desiredVelocity3 *= num1399 * 0.45f;
            }
            else
            {
                desiredVelocity3.Normalize();
                desiredVelocity3 *= num1399;
            }
            NPC.SimpleFlyMovement(desiredVelocity3, moveSpeed);
            NPC.rotation = NPC.velocity.X * 0.1f;
            if ((NPC.ai[0] += 1f) >= 70f)
            {
                NPC.ai[0] = 0f;
                if (Main.netMode != 1)
                {
                    Vector2 vector245 = Vector2.Zero;
                    while (Math.Abs(vector245.X) < 1.5f)
                    {
                        vector245 = Vector2.UnitY.RotatedByRandom(1.5707963705062866) * new Vector2(5f, 3f);
                    }
                    float Speed = 20f;
                    Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 4), NPC.position.Y + (NPC.height / 4));
                    int damage = 18;
                    int type = ModContent.ProjectileType<AzureWaveProjectile>();
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    return;
                }
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.expertMode || Main.rand.Next(2) == 0)
            {
                target.AddBuff(ModContent.BuffType<SirensLament>(), 200, true);
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "Arroya";
            potionType = ItemID.HealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SymphonyTrophy>(), 10));
        }
    }
}
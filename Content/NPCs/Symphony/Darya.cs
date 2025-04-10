using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Items.Symphony;
using TrelamiumRemastered.Content.Projectiles.Boss.Symphony;

namespace TrelamiumRemastered.Content.NPCs.Symphony
{
    [AutoloadBossHead]
    public class Darya : ModNPC
    {
        public int Timer = 800;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Darya, Siren of Lament");
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
            NPC.lifeMax = 2000;
            NPC.damage = 38;
            NPC.defense = 8;
            NPC.width = 112;
            NPC.height = 118;
            NPC.npcSlots = 5f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            AnimationType = 48;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[ModContent.BuffType<SirensLament>()] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Ichor] = true;
            //npc.buffImmune[ModContent.BuffType<SuperSlimed>()] = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
        }
        public override void AI()
        {
            if (NPC.alpha > 0)
            {
                NPC.alpha -= 30;
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                }
            }
            if (NPC.Center.X < Main.player[NPC.target].Center.X - 2f)
            {
                NPC.direction = 1;
            }
            if (NPC.Center.X > Main.player[NPC.target].Center.X + 2f)
            {
                NPC.direction = -1;
            }
            NPC.spriteDirection = NPC.direction;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            int num;
            for (int num1277 = 0; num1277 < 200; num1277 = num + 1)
            {
                if (num1277 != NPC.whoAmI && Main.npc[num1277].active && Main.npc[num1277].type == NPC.type)
                {
                    Vector2 vector227 = Main.npc[num1277].Center - NPC.Center;
                    if (vector227.Length() < 20f)
                    {
                        vector227.Normalize();
                        if (vector227.X == 0f && vector227.Y == 0f)
                        {
                            if (num1277 > NPC.whoAmI)
                            {
                                vector227.X = 1f;
                            }
                            else
                            {
                                vector227.X = -1f;
                            }
                        }
                        vector227 *= 0.12f;
                        NPC.velocity -= vector227;
                        NPC nPC6 = Main.npc[num1277];
                        nPC6.velocity += vector227;
                    }
                }
                num = num1277;

                float num1278 = 180f;
                if (NPC.localAI[0] < num1278)
                {
                    if (NPC.localAI[0] == 0f)
                    {
                        SoundEngine.PlaySound(SoundID.Item8, NPC.Center);
                        NPC.TargetClosest(true);
                        if (NPC.direction > 0)
                        {
                            NPC.velocity.X = NPC.velocity.X + 2f;
                        }
                        else
                        {
                            NPC.velocity.X = NPC.velocity.X - 2f;
                        }
                        for (int num1279 = 0; num1279 < 20; num1279 = num + 1)
                        {
                            Vector2 vector228 = NPC.Center;
                            vector228.Y -= 18f;
                            Vector2 value35 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            value35.Normalize();
                            value35 *= (float)Main.rand.Next(0, 100) * 0.1f;
                            vector228 += value35;
                            value35.Normalize();
                            value35 *= (float)Main.rand.Next(50, 90) * 0.2f;
                            int num1280 = Dust.NewDust(vector228, 1, 1, 27, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[num1280].velocity = -value35 * 0.3f;
                            Main.dust[num1280].alpha = 100;
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.dust[num1280].noGravity = true;
                                Dust dust3 = Main.dust[num1280];
                                dust3.scale += 0.3f;
                            }
                            num = num1279;
                        }
                    }
                    NPC.localAI[0] += 1f;
                    float num1281 = 1f - NPC.localAI[0] / num1278;
                    float num1282 = num1281 * 20f;
                    int num1283 = 0;
                    while ((float)num1283 < num1282)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            int num1284 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 172, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[num1284].alpha = 100;
                            Dust dust3 = Main.dust[num1284];
                            dust3.velocity *= 0.3f;
                            dust3 = Main.dust[num1284];
                            dust3.velocity += NPC.velocity * 0.75f;
                            Main.dust[num1284].noGravity = true;
                        }
                        num = num1283;
                        num1283 = num + 1;
                    }
                }
            }
            if (NPC.ai[0] == 0f)
            {
                NPC.TargetClosest(true);
                NPC.ai[0] = 1f;
                NPC.ai[1] = (float)NPC.direction;
            }
            else if (NPC.ai[0] == 1f)
            {
                NPC.TargetClosest(true);
                float num1289 = 0.3f;
                float num1290 = 7f;
                float num1291 = 4f;
                float num1292 = 660f;
                float num1293 = 4f;
                NPC.velocity.X = NPC.velocity.X + NPC.ai[1] * num1289;
                if (NPC.velocity.X > num1290)
                {
                    NPC.velocity.X = num1290;
                }
                if (NPC.velocity.X < -num1290)
                {
                    NPC.velocity.X = -num1290;
                }
                float num1294 = Main.player[NPC.target].Center.Y - NPC.Center.Y;
                if (Math.Abs(num1294) > num1291)
                {
                    num1293 = 15f;
                }
                if (num1294 > num1291)
                {
                    num1294 = num1291;
                }
                else if (num1294 < -num1291)
                {
                    num1294 = -num1291;
                }
                NPC.velocity.Y = (NPC.velocity.Y * (num1293 - 1f) + num1294) / num1293;
                if ((NPC.ai[1] > 0f && Main.player[NPC.target].Center.X - NPC.Center.X < -num1292) || (NPC.ai[1] < 0f && Main.player[NPC.target].Center.X - NPC.Center.X > num1292))
                {
                    NPC.ai[0] = 2f;
                    NPC.ai[1] = 0f;
                    if (NPC.Center.Y + 20f > Main.player[NPC.target].Center.Y)
                    {
                        NPC.ai[1] = -1f;
                    }
                    else
                    {
                        NPC.ai[1] = 1f;
                    }
                }
            }
            else if (NPC.ai[0] == 2f)
            {
                float num1295 = 0.4f;
                float scaleFactor13 = 0.95f;
                float num1296 = 5f;
                NPC.velocity.Y = NPC.velocity.Y + NPC.ai[1] * num1295;
                if (NPC.velocity.Length() > num1296)
                {
                    NPC.velocity *= scaleFactor13;
                }
                if (NPC.velocity.X > -1f && NPC.velocity.X < 1f)
                {
                    NPC.TargetClosest(true);
                    NPC.ai[0] = 3f;
                    NPC.ai[1] = (float)NPC.direction;
                }
            }
            else if (NPC.ai[0] == 3f)
            {
                float num1297 = 0.4f;
                float num1298 = 0.2f;
                float num1299 = 5f;
                float scaleFactor14 = 0.95f;
                NPC.velocity.X = NPC.velocity.X + NPC.ai[1] * num1297;
                if (NPC.Center.Y > Main.player[NPC.target].Center.Y)
                {
                    NPC.velocity.Y = NPC.velocity.Y - num1298;
                }
                else
                {
                    NPC.velocity.Y = NPC.velocity.Y + num1298;
                }
                if (NPC.velocity.Length() > num1299)
                {
                    NPC.velocity *= scaleFactor14;
                }
                if (NPC.velocity.Y > -1f && NPC.velocity.Y < 1f)
                {
                    NPC.TargetClosest(true);
                    NPC.ai[0] = 0f;
                    NPC.ai[1] = (float)NPC.direction;
                }
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.expertMode || Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.VortexDebuff, 180, true);
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "Darya";
            potionType = ItemID.HealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SymphonyTrophy>(), 10));
        }
    }
}
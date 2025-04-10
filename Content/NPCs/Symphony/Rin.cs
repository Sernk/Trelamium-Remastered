using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Items.Symphony;
using TrelamiumRemastered.Content.Projectiles.Boss.Symphony;

namespace TrelamiumRemastered.Content.NPCs.Symphony
{
    [AutoloadBossHead]
    public class Rin : ModNPC
    {
        public int Timer = 0;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rin, The Illusionist");
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
            NPC.lifeMax = 3850;
            NPC.damage = 42;
            NPC.defense = 6;
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
            Music = MusicLoader.GetMusicSlot("TrelamiumRemastered/Sounds/Music/SymphonyTheme");
            NPC.value = Item.buyPrice(0, 10, 0, 0);
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
            if (NPC.AnyNPCs(ModContent.NPCType<Arroya>()) && NPC.AnyNPCs(ModContent.NPCType<Darya>()))
            {
                NPC.dontTakeDamage = true;
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Arroya>()) && NPC.AnyNPCs(ModContent.NPCType<Darya>()))
            {
                NPC.dontTakeDamage = false;
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
            NPC.TargetClosest(true);
            float num905 = 10f;
            Vector2 vector124 = new Vector2(NPC.Center.X + (float)(NPC.direction * 15), NPC.Center.Y + 6f);
            float num906 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector124.X;
            float num907 = Main.player[NPC.target].Center.Y - vector124.Y;
            float num908 = (float)Math.Sqrt((double)(num906 * num906 + num907 * num907));
            float num909 = num905 / num908;
            num906 *= num909;
            num907 *= num909;
            NPC.ai[0] -= 1f;
            if (num908 < 200f || NPC.ai[0] > 0f)
            {
                if (num908 < 200f)
                {
                    NPC.ai[0] = 20f;
                }
                if (NPC.velocity.X < 0f)
                {
                    NPC.direction = -1;
                }
                else
                {
                    NPC.direction = 1;
                }
                return;
            }
            NPC.velocity.X = (NPC.velocity.X * 40f + num906) / 41f;
            NPC.velocity.Y = (NPC.velocity.Y * 40f + num907) / 41f;
            if (num908 < 350f)
            {
                NPC.velocity.X = (NPC.velocity.X * 10f + num906) / 11f;
                NPC.velocity.Y = (NPC.velocity.Y * 10f + num907) / 11f;
            }
            if (num908 < 300f)
            {
                NPC.velocity.X = (NPC.velocity.X * 7f + num906) / 8f;
                NPC.velocity.Y = (NPC.velocity.Y * 7f + num907) / 8f;
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Arroya>()) && NPC.AnyNPCs(ModContent.NPCType<Darya>()))
            {
                NPC.localAI[1] += 1f;
                if (NPC.localAI[1] == 200f)
                {
                    Vector2 vector116 = new Vector2(NPC.Center.X, NPC.Center.Y);
                    vector116.X += NPC.velocity.X * 7f;
                    float num858 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector116.X;
                    float num859 = Main.player[NPC.target].Center.Y - vector116.Y;
                    float num860 = (float)Math.Sqrt((double)(num858 * num858 + num859 * num859));
                    float num861 = 5f;
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                    {
                        num861 = 6f;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                    {
                        num861 = 7.5f;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                    {
                        num861 = 8.5f;
                    }
                    num860 = num861 / num860;
                    num858 *= num860;
                    num859 *= num860;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), vector116.X, vector116.Y, num858, num859, ModContent.ProjectileType<AzureWaveProjectile>(), 18, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            
            float num18 = 110f;
            if (Main.expertMode)
            {
                num18 *= 0.4f;
            }
            if (NPC.ai[3] >= num18)
            {
                NPC.ai[3] = 0f;
                //float num19 = 5f;
                //if (Main.expertMode)
                //{
                //    num19 = 6f;
                //}
                Vector2 vector2 = NPC.Center;
                if (Main.netMode != 1)
                {
                    //int num23;
                    //int num23 = NPC.NewNPC(NPC.GetSource_FromThis(), (int)vector2.X, (int)vector2.Y, ModContent.NPCType<DepthStarfish>(), 0, 0f, 0f, 0f, 0f, 255);
                    //if (Main.netMode == 2 && num23 < 200)
                    //{
                    //    NetMessage.SendData(23, -1, -1, null, num23, 0f, 0f, 0f, 0, 0, 0);
                    //}
                }
            }
        }
        
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.expertMode)
            {
                if (Main.rand.Next(3) == 0)
                {
                    target.AddBuff(BuffID.Obstructed, 200, true);
                }
            }
            if (!Main.expertMode)
            {
                if (Main.rand.Next(4) == 0)
                {
                    target.AddBuff(BuffID.Obstructed, 100, true);
                }
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "The Symphony";
            potionType = ItemID.HealingPotion;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SymphonyTrophy>(), 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Aquafinity>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AquarianPiccolo>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LeviathansClasp>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LeviathansClasp>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TideOfTheGods>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DepthStone>(), 1, 10, 18));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SymphonyBag>(), 1));
        }

        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedSymphony)
            {
                Main.NewText("The Tides have begun to settle down...", new Color(40, 127, 225));
                TrelamiumModWorld.downedSymphony = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}
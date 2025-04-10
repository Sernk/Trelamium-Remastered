using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Boss.Cumulor;
using TrelamiumRemastered.Content.Items.Aureolus;
using Terraria.GameContent.ItemDropRules;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.NPCs.Aureolus
{
    [AutoloadBossHead]
    public class AureolusBosss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aureolus, the Ruler of Skies");
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 4000;
            NPC.damage = 35;
            NPC.defense = 20;
            NPC.knockBackResist = 0f;
            NPC.width = 224;
            NPC.height = 206;
            NPC.value = Item.buyPrice(0, 8, 50, 0);
            NPC.npcSlots = 10f;
            NPC.boss = true;
            AnimationType = 179;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[BuffID.Electrified] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.HitSound = SoundID.NPCHit20;
            NPC.DeathSound = SoundID.NPCDeath33;
            Music = MusicID.Boss1;
            //bossBag = mod.ItemType("AureolusBag");
        }
        public override void AI()
        {
            if (NPC.Center.X < Main.player[NPC.target].Center.X - 2f)
            {
                NPC.direction = -1;
            }
            if (NPC.Center.X > Main.player[NPC.target].Center.X + 2f)
            {
                NPC.direction = 1;
            }
            NPC.spriteDirection = NPC.direction;
            Lighting.AddLight(NPC.Center, 1.75f, 1f, 2.25f);
            Player player = Main.player[NPC.target];
            if (NPC.target < 0 || !Main.raining || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.25f;
                }
                else
                {
                    NPC.velocity.X = NPC.velocity.X - 0.25f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                NPC.rotation = NPC.velocity.X * 0.05f;
            }
            else if (NPC.ai[0] == 0f)
            {
                if (NPC.ai[2] == 0f)
                {
                    NPC.TargetClosest(true);
                    if (NPC.Center.X < Main.player[NPC.target].Center.X)
                    {
                        NPC.ai[2] = 1f;
                    }
                    else
                    {
                        NPC.ai[2] = -1f;
                    }
                }
                NPC.localAI[1] += 1f;
                if (NPC.localAI[1] == 400f)
                {
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), ModContent.NPCType<LamentedNimbus>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                }
                if (NPC.localAI[1] >= 400f)
                {
                    NPC.localAI[1] = 0f;
                    NPC.localAI[0] = 0f;
                }
                NPC.TargetClosest(true);
                int num852 = 800;
                float num853 = Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X);
                if (NPC.Center.X < Main.player[NPC.target].Center.X && NPC.ai[2] < 0f && num853 > (float)num852)
                {
                    NPC.ai[2] = 0f;
                }
                if (NPC.Center.X > Main.player[NPC.target].Center.X && NPC.ai[2] > 0f && num853 > (float)num852)
                {
                    NPC.ai[2] = 0f;
                }
                float num854 = 0.45f;
                float num855 = 7f;
                if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                {
                    num854 = 0.55f;
                    num855 = 8f;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                {
                    num854 = 0.7f;
                    num855 = 10f;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                {
                    num854 = 0.8f;
                    num855 = 11f;
                }
                NPC.velocity.X = NPC.velocity.X + NPC.ai[2] * num854;
                if (NPC.velocity.X > num855)
                {
                    NPC.velocity.X = num855;
                }
                if (NPC.velocity.X < -num855)
                {
                    NPC.velocity.X = -num855;
                }
                float num856 = Main.player[NPC.target].position.Y - (NPC.position.Y + (float)NPC.height);
                if (num856 < 150f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                }
                if (num856 > 200f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                }
                if (NPC.velocity.Y > 8f)
                {
                    NPC.velocity.Y = 8f;
                }
                if (NPC.velocity.Y < -8f)
                {
                    NPC.velocity.Y = -8f;
                }
                NPC.rotation = NPC.velocity.X * 0.05f;
                if ((num853 < 500f || NPC.ai[3] < 0f) && NPC.position.Y < Main.player[NPC.target].position.Y)
                {
                    NPC.ai[3] += 1f;
                    int num857 = 13;
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                    {
                        num857 = 12;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                    {
                        num857 = 11;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                    {
                        num857 = 10;
                    }
                    int num = num857;
                    num857 = num + 1;
                    if (NPC.ai[3] > (float)num857)
                    {
                        NPC.ai[3] = -(float)num857;
                    }
                    if (NPC.ai[3] == 0f && Main.netMode != 1)
                    {
                        Vector2 vector116 = new Vector2(NPC.Center.X, NPC.Center.Y);
                        vector116.X += NPC.velocity.X * 7f;
                        float num858 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector116.X;
                        float num859 = Main.player[NPC.target].Center.Y - vector116.Y;
                        float num860 = (float)Math.Sqrt((double)(num858 * num858 + num859 * num859));
                        float num861 = 6f;
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                        {
                            num861 = 7f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                        {
                            num861 = 8f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                        {
                            num861 = 9f;
                        }
                        num860 = num861 / num860;
                        num858 *= num860;
                        num859 *= num860;
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), vector116.X, vector116.Y, num858, num859, ModContent.ProjectileType<WhirlingWindProjectile>(), 20, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                else if (NPC.ai[3] < 0f)
                {
                    NPC.ai[3] += 1f;
                }
                if (Main.netMode != 1)
                {
                    NPC.ai[1] += (float)Main.rand.Next(1, 4);
                    if (NPC.ai[1] > 800f && num853 < 600f)
                    {
                        NPC.ai[0] = -1f;
                    }
                }
            }
            else if (NPC.ai[0] == 1f)
            {
                NPC.TargetClosest(true);
                float num862 = 0.15f;
                float num863 = 7f;
                if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                {
                    num862 = 0.17f;
                    num863 = 8f;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                {
                    num862 = 0.2f;
                    num863 = 9f;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                {
                    num862 = 0.25f;
                    num863 = 10f;
                }
                num862 -= 0.05f;
                num863 -= 1f;
                if (NPC.Center.X < Main.player[NPC.target].Center.X)
                {
                    NPC.velocity.X = NPC.velocity.X + num862;
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.98f;
                    }
                }
                if (NPC.Center.X > Main.player[NPC.target].Center.X)
                {
                    NPC.velocity.X = NPC.velocity.X - num862;
                    if (NPC.velocity.X > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.98f;
                    }
                }
                if (NPC.velocity.X > num863 || NPC.velocity.X < -num863)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.95f;
                }
                float num864 = Main.player[NPC.target].position.Y - (NPC.position.Y + (float)NPC.height);
                if (num864 < 180f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                }
                if (num864 > 200f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                }
                if (NPC.velocity.Y > 6f)
                {
                    NPC.velocity.Y = 6f;
                }
                if (NPC.velocity.Y < -6f)
                {
                    NPC.velocity.Y = -6f;
                }
                NPC.rotation = NPC.velocity.X * 0.01f;
                if (Main.netMode != 1)
                {
                    NPC.ai[3] += 1f;
                    int num865 = 10;
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                    {
                        num865 = 9;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                    {
                        num865 = 8;
                    }
                    if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                    {
                        num865 = 7;
                    }

                    num865 += 3;
                    if (NPC.ai[3] >= (float)num865)
                    {
                        NPC.ai[3] = 0f;
                        Vector2 vector117 = new Vector2(NPC.Center.X, NPC.position.Y + (float)NPC.height - 14f);
                        int i2 = (int)(vector117.X / 16f);
                        int j2 = (int)(vector117.Y / 16f);
                        if (!WorldGen.SolidTile(i2, j2))
                        {
                            float num866 = NPC.velocity.Y;
                            if (num866 < 0f)
                            {
                                num866 = 0f;
                            }
                            num866 += 3f;
                            float speedX2 = NPC.velocity.X * 1.25f;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), vector117.X, vector117.Y, speedX2, num866, ModContent.ProjectileType<LamentRainProjectile>(), 30, 0f, Main.myPlayer, (float)Main.rand.Next(5), 0f);
                        }
                    }
                }
                if (Main.netMode != 1)
                {
                    NPC.ai[1] += (float)Main.rand.Next(1, 4);
                    if (NPC.ai[1] > 600f)
                    {
                        NPC.ai[0] = -1f;
                    }
                }
            }
            else if (NPC.ai[0] == 2f)
            {
                NPC.TargetClosest(true);
                Vector2 vector118 = new Vector2(NPC.Center.X, NPC.Center.Y - 20f);
                float num867 = (float)Main.rand.Next(-1000, 1001);
                float num868 = (float)Main.rand.Next(-1000, 1001);
                float num869 = (float)Math.Sqrt((double)(num867 * num867 + num868 * num868));
                float num870 = 15f;
                NPC.velocity *= 0.95f;
                num869 = num870 / num869;
                num867 *= num869;
                num868 *= num869;
                NPC.rotation += 0.2f;
                vector118.X += num867 * 4f;
                vector118.Y += num868 * 4f;
                NPC.ai[3] += 1f;
                int num871 = 7;
                if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                {
                    int num = num871;
                    num871 = num - 3;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                {
                    num871 -= 4;
                }
                if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                {
                    num871 -= 5;
                }

                if (NPC.ai[3] > (float)num871)
                {
                    NPC.ai[3] = 0f;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), vector118.X, vector118.Y, num867, num868, ModContent.ProjectileType<AureoleCloudProjectile>(), 20, 0f, Main.myPlayer, 0f, 0f);
                }
                if (Main.netMode != 1)
                {
                    NPC.ai[1] += (float)Main.rand.Next(1, 4);
                    if (NPC.ai[1] > 500f)
                    {
                        NPC.ai[0] = -1f;
                    }
                }
            }
            if (NPC.ai[0] == -1f)
            {
                int num872 = Main.rand.Next(3);
                NPC.TargetClosest(true);
                if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 1000f)
                {
                    num872 = 0;
                }
                NPC.ai[0] = (float)num872;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                return;
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 31, hitDirection, -1f, 100, default(Color), 1f);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CumulorMask>(), 7)); - 
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheKingsTear>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AureolusTrophy>(), 5));

            npcLoot.Add(ItemDropRule.OneFromOptions(1,
               ModContent.ItemType<CumulorsRemnants>(),
               ModContent.ItemType<AerialStrider>(),
               //ModContent.ItemType<NimbusStaff>(), -
               ModContent.ItemType<CloudBuster>()
           ));
        }

        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedCumulor)
            {
                TrelamiumModWorld.downedCumulor = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Electrified, 60, true);
            if (Main.expertMode || Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Electrified, 120, true);
            }
        }
    }
}
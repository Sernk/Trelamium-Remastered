using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Items.Azolinth;
using TrelamiumRemastered.Content.Items.Permafrost;
using TrelamiumRemastered.Content.Projectiles.Boss.Permafrost;

namespace TrelamiumRemastered.Content.NPCs.Permafrost
{
    [AutoloadBossHead]
    public class PermafrostRun : ModNPC
    {
        public int halfHealth = 0;
        public int halfHealth2 = 0;
        public int halfHealth3 = 0;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Permafrost");
            Main.npcFrameCount[NPC.type] = 6;
        }
        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 28000;
            NPC.damage = 20;
            NPC.defense = 10;
            AnimationType = NPCID.Retinazer;
            NPC.knockBackResist = 0f;
            NPC.width = 108;
            NPC.height = 108;
            NPC.value = Item.buyPrice(0, 20, 0, 0);
            NPC.npcSlots = 15f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.coldDamage = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.Item110;
            NPC.DeathSound = SoundID.Item123;
            NPC.buffImmune[BuffID.Frostburn] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Burning] = true;
            NPC.buffImmune[ModContent.BuffType<PermafrostBuff>()] = true;
            Music = MusicLoader.GetMusicSlot("TrelamiumRemastered/Sounds/Music/AntiFreezeTheme");
            //bossBag = mod.ItemType("PermafrostBag");
        }
        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0f, 0.2f, 0.5f);
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            if (halfHealth == 0 && ((double)NPC.life < (double)NPC.lifeMax * 0.65))
            {
                Main.NewText("The more you try only weakens your strength...", new Color(50, 112, 255));
                halfHealth++;
            }
            if (halfHealth2 == 0 && ((double)NPC.life < (double)NPC.lifeMax * 0.45))
            {
                Main.NewText("You suprise me, but this ends here...", new Color(50, 112, 255));
                halfHealth2++;
            }
            if (halfHealth3 == 0 && (double)NPC.life < (double)NPC.lifeMax * 0.35)
            {
                Main.NewText("Frigid elementals are emerging...", new Color(50, 112, 255));
                int num248 = Main.rand.Next(1, 2);
                int num;
                for (int num249 = 0; num249 < num248; num249 = num + 1)
                {
                    int x = (int)(NPC.position.X + (float)Main.rand.Next(NPC.width - 32));
                    int y = (int)(NPC.position.Y + (float)Main.rand.Next(NPC.height - 32));
                    int type = ModContent.NPCType<Frigid>();
                    int num251 = NPC.NewNPC(NPC.GetSource_FromThis(), x, y, type, 0, 0f, 0f, 0f, 0f, 255);
                    Main.npc[num251].SetDefaults(type, new NPCSpawnParams());
                    Main.npc[num251].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
                    Main.npc[num251].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
                    if (Main.netMode == 2 && num251 < 200)
                    {
                        NetMessage.SendData(23, -1, -1, null, num251, 0f, 0f, 0f, 0, 0, 0);
                    }
                    halfHealth3++;
                    num = num249;
                }
                return;
            }
        
            bool dead3 = Main.player[NPC.target].dead;
            float num407 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
            float num408 = NPC.position.Y + (float)NPC.height - 59f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
            float num409 = (float)Math.Atan2((double)num408, (double)num407) + 1.57f;
            if (num409 < 0f)
            {
                num409 += 6.283f;
            }
            else if ((double)num409 > 6.283)
            {
                num409 -= 6.283f;
            }
            float num410 = 0.15f;
            if (NPC.rotation < num409)
            {
                if ((double)(num409 - NPC.rotation) > 3.1415)
                {
                    NPC.rotation -= num410;
                }
                else
                {
                    NPC.rotation += num410;
                }
            }
            else if (NPC.rotation > num409)
            {
                if ((double)(NPC.rotation - num409) > 3.1415)
                {
                    NPC.rotation += num410;
                }
                else
                {
                    NPC.rotation -= num410;
                }
            }
            if (NPC.rotation > num409 - num410 && NPC.rotation < num409 + num410)
            {
                NPC.rotation = num409;
            }
            if (NPC.rotation < 0f)
            {
                NPC.rotation += 6.283f;
            }
            else if ((double)NPC.rotation > 6.283)
            {
                NPC.rotation -= 6.283f;
            }
            if (NPC.rotation > num409 - num410 && NPC.rotation < num409 + num410)
            {
                NPC.rotation = num409;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num411 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), 5, NPC.velocity.X, 2f, 0, default(Color), 1f);
                Dust dust29 = Main.dust[num411];
                dust29.velocity.X = dust29.velocity.X * 0.5f;
                Dust dust30 = Main.dust[num411];
                dust30.velocity.Y = dust30.velocity.Y * 0.1f;
            }
            if (Main.netMode != 1 && !Main.dayTime && !dead3 && NPC.timeLeft < 10)
            {
                int num;
                for (int num412 = 0; num412 < 200; num412 = num + 1)
                {
                    if (num412 != NPC.whoAmI && Main.npc[num412].active && (Main.npc[num412].type == 125 || Main.npc[num412].type == 126) && Main.npc[num412].timeLeft - 1 > NPC.timeLeft)
                    {
                        NPC.timeLeft = Main.npc[num412].timeLeft - 1;
                    }
                    num = num412;
                }
            }
            if (Main.dayTime | dead3)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.04f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                    return;
                }
            }
            else if (NPC.ai[0] == 0f)
            {
                if (NPC.ai[1] == 0f)
                {
                    NPC.TargetClosest(true);
                    float num413 = 18f;
                    float num414 = 0.12f;
                    int num415 = 1;
                    if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
                    {
                        num415 = -1;
                    }
                    Vector2 vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float num416 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num415 * 400) - vector44.X;
                    float num417 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
                    float num418 = (float)Math.Sqrt((double)(num416 * num416 + num417 * num417));
                    num418 = num413 / num418;
                    num416 *= num418;
                    num417 *= num418;
                    if (Main.expertMode)
                    {
                        if (num418 > 300f)
                        {
                            num413 += 0.5f;
                        }
                        if (num418 > 400f)
                        {
                            num413 += 0.5f;
                        }
                        if (num418 > 500f)
                        {
                            num413 += 0.55f;
                        }
                        if (num418 > 600f)
                        {
                            num413 += 0.55f;
                        }
                        if (num418 > 700f)
                        {
                            num413 += 0.6f;
                        }
                        if (num418 > 800f)
                        {
                            num413 += 0.6f;
                        }
                    }
                    num418 = num413 / num418;
                    num416 *= num418;
                    num417 *= num418;
                    if (NPC.velocity.X < num416)
                    {
                        NPC.velocity.X = NPC.velocity.X + num414;
                        if (NPC.velocity.X < 0f && num416 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num414;
                        }
                    }
                    else if (NPC.velocity.X > num416)
                    {
                        NPC.velocity.X = NPC.velocity.X - num414;
                        if (NPC.velocity.X > 0f && num416 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num414;
                        }
                    }
                    if (NPC.velocity.Y < num417)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num414;
                        if (NPC.velocity.Y < 0f && num417 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num414;
                        }
                    }
                    else if (NPC.velocity.Y > num417)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num414;
                        if (NPC.velocity.Y > 0f && num417 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num414;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 600f)
                    {
                        NPC.ai[1] = 1f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.target = 255;
                        NPC.netUpdate = true;
                    }
                    else
                    {
                        if (!Main.player[NPC.target].dead)
                        {
                            NPC.ai[3] += 1f;
                            if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
                            {
                                NPC.ai[3] += 0.8f;
                            }
                        }
                        if (NPC.ai[3] >= 60f)
                        {
                            NPC.ai[3] = 0f;
                            vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                            num416 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector44.X;
                            num417 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
                            if (Main.netMode != 1)
                            {
                                float velocity = 12f;
                                int damage = 25;
                                int projectile = ModContent.ProjectileType<CryoxisBeamProjectile>();
                                if (Main.expertMode)
                                {
                                    velocity = 14f;
                                    damage = 30;
                                }
                                num418 = (float)Math.Sqrt((double)(num416 * num416 + num417 * num417));
                                num418 = velocity / num418;
                                num416 *= num418;
                                num417 *= num418;
                                num416 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                num417 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                vector44.X += num416 * 4f;
                                vector44.Y += num417 * 4f;
                                Projectile.NewProjectile(NPC.GetSource_FromThis(), vector44.X, vector44.Y, num416, num417, projectile, damage, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                else if (NPC.ai[1] == 1f)
                {
                    NPC.rotation = num409;
                    float num422 = 13f;
                    if (Main.expertMode)
                    {
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.9)
                        {
                            num422 += 0.65f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.8)
                        {
                            num422 += 0.70f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.7)
                        {
                            num422 += 0.75f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.6)
                        {
                            num422 += 0.80f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                        {
                            num422 += 0.85f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.45)
                        {
                            num422 += 1.10f;
                        }
                    }
                    Vector2 vector45 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float num423 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector45.X;
                    float num424 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector45.Y;
                    float num425 = (float)Math.Sqrt((double)(num423 * num423 + num424 * num424));
                    num425 = num422 / num425;
                    NPC.velocity.X = num423 * num425;
                    NPC.velocity.Y = num424 * num425;
                    NPC.ai[1] = 2f;
                }
                else if (NPC.ai[1] == 2f)
                {
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 8f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.9f;
                        NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                        if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
                        {
                            NPC.velocity.X = 0f;
                        }
                        if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
                        {
                            NPC.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) - 1.57f;
                    }
                    if (NPC.ai[2] >= 42f)
                    {
                        NPC.ai[3] += 1f;
                        NPC.ai[2] = 0f;
                        NPC.target = 255;
                        NPC.rotation = num409;
                        if (NPC.ai[3] >= 10f)
                        {
                            NPC.ai[1] = 0f;
                            NPC.ai[3] = 0f;
                        }
                        else
                        {
                            NPC.ai[1] = 1f;
                        }
                    }
                }
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;
            for (int k = 0; k < hit.Damage / NPC.lifeMax * 100.0; k++)
            {
                int DustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, hitDirection, -1f, 0, default(Color), 1f);
                int DustIndex2 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 113, hitDirection, -1f, 0, default(Color), 1f);
                Main.dust[DustIndex].noGravity = true;
                Main.dust[DustIndex2].noGravity = true;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 200, true);
            if (Main.expertMode || Main.rand.Next(2) == 0)
            {
                target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 300, true);
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "Permafrost";
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PermafrostMask>(), 7)); --
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<ThermalCleaver>(), ModContent.ItemType<GlacialFloe>(), ModContent.ItemType<CryotineShard>(), ModContent.ItemType<ColdbloomTome>(), ModContent.ItemType<GlaciersMememto>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PermafrostTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<PermafrostBag>(), 1));
        }
        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedPermafrost)
            {
                Main.NewText("The scourge is getting closer and closer...", new Color(81, 127, 244));
                TrelamiumModWorld.downedPermafrost = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}
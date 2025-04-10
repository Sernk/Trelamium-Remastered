using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Projectiles.Boss.Permafrost;

namespace TrelamiumRemastered.Content.NPCs.Permafrost
{
    [AutoloadBossHead]
    public class PermafrostBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Permafrost");
            Main.npcFrameCount[NPC.type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 12000;
            NPC.damage = 20;
            NPC.defense = 10;
            AnimationType = NPCID.Retinazer;
            NPC.knockBackResist = 0f;
            NPC.width = 108;
            NPC.height = 108;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.npcSlots = 15f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.Item110;
            NPC.coldDamage = true;
            NPC.DeathSound = SoundID.Item30;
            NPC.buffImmune[24] = true;
            Music = MusicLoader.GetMusicSlot("TrelamiumRemastered/Sounds/Music/PermafrostTheme");
        }
        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0f, 0.2f, 0.5f);
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            bool dead2 = Main.player[NPC.target].dead;
            float num368 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
            float num369 = NPC.position.Y + (float)NPC.height - 60f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
            float num370 = (float)Math.Atan2((double)num369, (double)num368) + 1.80f;
            if (num370 < 0f)
            {
                num370 += 6.283f;
            }
            else if ((double)num370 > 6.283)
            {
                num370 -= 6.283f;
            }
            float num371 = 0.1f;
            if (NPC.rotation < num370)
            {
                if ((double)(num370 - NPC.rotation) > 3.1415)
                {
                    NPC.rotation -= num371;
                }
                else
                {
                    NPC.rotation += num371;
                }
            }
            else if (NPC.rotation > num370)
            {
                if ((double)(NPC.rotation - num370) > 3.1415)
                {
                    NPC.rotation += num371;
                }
                else
                {
                    NPC.rotation -= num371;
                }
            }
            if (NPC.rotation > num370 - num371 && NPC.rotation < num370 + num371)
            {
                NPC.rotation = num370;
            }
            if (NPC.rotation < 0f)
            {
                NPC.rotation += 6.283f;
            }
            else if ((double)NPC.rotation > 6.283)
            {
                NPC.rotation -= 6.283f;
            }
            if (NPC.rotation > num370 - num371 && NPC.rotation < num370 + num371)
            {
                NPC.rotation = num370;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num372 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), 5, NPC.velocity.X, 2f, 0, default(Color), 1f);
                Dust dust27 = Main.dust[num372];
                dust27.velocity.X = dust27.velocity.X * 0.5f;
                Dust dust28 = Main.dust[num372];
                dust28.velocity.Y = dust28.velocity.Y * 0.1f;
            }
            if (Main.netMode != 1 && !Main.dayTime && !dead2 && NPC.timeLeft < 10)
            {
                int num;
                for (int num373 = 0; num373 < 200; num373 = num + 1)
                {
                    if (num373 != NPC.whoAmI && Main.npc[num373].active && (Main.npc[num373].type == 125 || Main.npc[num373].type == 126) && Main.npc[num373].timeLeft - 1 > NPC.timeLeft)
                    {
                        NPC.timeLeft = Main.npc[num373].timeLeft - 1;
                    }
                    num = num373;
                }
            }
            if (Main.dayTime | dead2)
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
                    float num374 = 7f;
                    float num375 = 0.1f;
                    if (Main.expertMode)
                    {
                        num374 = 8.25f;
                        num375 = 0.115f;
                    }
                    int num376 = 1;
                    if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
                    {
                        num376 = -1;
                    }
                    Vector2 Vector10 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float positionX = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num376 * 300) - Vector10.X;
                    float positionY = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - Vector10.Y;
                    float num379 = (float)Math.Sqrt((double)(positionX * positionX + positionY * positionY));
                    float num380 = num379;
                    num379 = num374 / num379;
                    positionX *= num379;
                    positionY *= num379;
                    if (NPC.velocity.X < positionX)
                    {
                        NPC.velocity.X = NPC.velocity.X + num375;
                        if (NPC.velocity.X < 0f && positionX > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num375;
                        }
                    }
                    else if (NPC.velocity.X > positionX)
                    {
                        NPC.velocity.X = NPC.velocity.X - num375;
                        if (NPC.velocity.X > 0f && positionX < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num375;
                        }
                    }
                    if (NPC.velocity.Y < positionY)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num375;
                        if (NPC.velocity.Y < 0f && positionY > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num375;
                        }
                    }
                    else if (NPC.velocity.Y > positionY)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num375;
                        if (NPC.velocity.Y > 0f && positionY < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num375;
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
                    else if (NPC.position.Y + (float)NPC.height < Main.player[NPC.target].position.Y && num380 < 400f)
                    {
                        if (!Main.player[NPC.target].dead)
                        {
                            NPC.ai[3] += 1f;
                            if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.9)
                            {
                                NPC.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
                            {
                                NPC.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.7)
                            {
                                NPC.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.6)
                            {
                                NPC.ai[3] += 0.3f;
                            }
                        }
                        if (NPC.ai[3] >= 60f)
                        {
                            NPC.ai[3] = 0f;
                            Vector10 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                            positionX = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - Vector10.X;
                            positionY = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - Vector10.Y;
                            if (Main.netMode != 1)
                            {
                                float num381 = 9f;
                                int damage = 20;
                                int projectile = ModContent.ProjectileType<CryoxisBeamProjectile>();
                                SoundEngine.PlaySound(SoundID.Item12, NPC.position);
                                if (Main.expertMode)
                                {
                                    num381 = 10.5f;
                                    damage = 30;
                                }
                                num379 = (float)Math.Sqrt((double)(positionX * positionX + positionY * positionY));
                                num379 = num381 / num379;
                                positionX *= num379;
                                positionY *= num379;
                                positionX += (float)Main.rand.Next(-40, 41) * 0.08f;
                                positionY += (float)Main.rand.Next(-40, 41) * 0.08f;
                                Vector10.X += positionX * 15f;
                                Vector10.Y += positionY * 15f;
                                Projectile.NewProjectile(NPC.GetSource_FromThis(), Vector10.X, Vector10.Y, positionX, positionY, projectile, damage, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                else if (NPC.ai[1] == 1f)
                {
                    NPC.rotation = num370;
                    float num384 = 12f;
                    if (Main.expertMode)
                    {
                        num384 = 15f;
                    }
                    Vector2 vector41 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float num385 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector41.X;
                    float num386 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector41.Y;
                    float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
                    num387 = num384 / num387;
                    NPC.velocity.X = num385 * num387;
                    NPC.velocity.Y = num386 * num387;
                    NPC.ai[1] = 2f;
                }
                else if (NPC.ai[1] == 2f)
                {
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 25f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
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
                    if (NPC.ai[2] >= 70f)
                    {
                        NPC.ai[3] += 1f;
                        NPC.ai[2] = 0f;
                        NPC.target = 255;
                        NPC.rotation = num370;
                        if (NPC.ai[3] >= 4f)
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
                if ((double)NPC.life < (double)NPC.lifeMax * 0.4)
                {
                    NPC.ai[0] = 1f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.netUpdate = true;
                    return;
                }
            }
            else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
            {
                if (NPC.ai[0] == 1f)
                {
                    NPC.ai[2] += 0.005f;
                    if ((double)NPC.ai[2] > 0.5)
                    {
                        NPC.ai[2] = 0.5f;
                    }
                }
                else
                {
                    NPC.ai[2] -= 0.005f;
                    if (NPC.ai[2] < 0f)
                    {
                        NPC.ai[2] = 0f;
                    }
                }
                NPC.rotation += NPC.ai[2];
                NPC.ai[1] += 1f;
                if (NPC.ai[1] == 100f)
                {
                    NPC.ai[0] += 1f;
                    NPC.ai[1] = 0f;
                    if (NPC.ai[0] == 3f)
                    {
                        NPC.ai[2] = 0f;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.NPCHit1, NPC.position);
                        int num;
                        for (int num388 = 0; num388 < 2; num388 = num + 1)
                        {
                            num = num388;
                        }
                        for (int num389 = 0; num389 < 20; num389 = num + 1)
                        {
                            Dust.NewDust(NPC.position, NPC.width, NPC.height, 229, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                            num = num389;
                        }
                        SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                    }
                }
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 113, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                NPC.velocity.X = NPC.velocity.X * 0.98f;
                NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
                {
                    NPC.velocity.X = 0f;
                }
                if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
                {
                    NPC.velocity.Y = 0f;
                    return;
                }
            }
            else
            {
                if (NPC.ai[1] == 0f)
                {
                    float num390 = 10f;
                    float num391 = 0.25f;
                    if (Main.expertMode)
                    {
                        num390 = 10.5f;
                        num391 = 0.185f;
                    }
                    Vector2 vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float num392 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
                    float num393 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector42.Y;
                    float num394 = (float)Math.Sqrt((double)(num392 * num392 + num393 * num393));
                    num394 = num390 / num394;
                    num392 *= num394;
                    num393 *= num394;
                    if (NPC.velocity.X < num392)
                    {
                        NPC.velocity.X = NPC.velocity.X + num391;
                        if (NPC.velocity.X < 0f && num392 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num391;
                        }
                    }
                    else if (NPC.velocity.X > num392)
                    {
                        NPC.velocity.X = NPC.velocity.X - num391;
                        if (NPC.velocity.X > 0f && num392 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num391;
                        }
                    }
                    if (NPC.velocity.Y < num393)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num391;
                        if (NPC.velocity.Y < 0f && num393 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num391;
                        }
                    }
                    else if (NPC.velocity.Y > num393)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num391;
                        if (NPC.velocity.Y > 0f && num393 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num391;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 300f)
                    {
                        NPC.ai[1] = 1f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.TargetClosest(true);
                        NPC.netUpdate = true;
                    }
                    vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    num392 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
                    num393 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector42.Y;
                    NPC.rotation = (float)Math.Atan2((double)num393, (double)num392) - 1.57f;
                    if (Main.netMode != 1)
                    {
                        NPC.localAI[1] += 1f;
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
                        {
                            NPC.localAI[1] += 2f;
                        }
                        if (NPC.localAI[1] > 180f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                        {
                            NPC.localAI[1] = 0f;
                            float num395 = 8.5f;
                            int damage = 30;
                            int projectile = ModContent.ProjectileType<CryoxisBeamProjectile>();
                            SoundEngine.PlaySound(SoundID.Item12, NPC.position);
                            if (Main.expertMode)
                            {
                                num395 = 10f;
                                damage = 23;
                            }
                            num394 = (float)Math.Sqrt((double)(num392 * num392 + num393 * num393));
                            num394 = num395 / num394;
                            num392 *= num394;
                            num393 *= num394;
                            vector42.X += num392 * 15f;
                            vector42.Y += num393 * 15f;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), vector42.X, vector42.Y, num392, num393, projectile, damage, 0f, Main.myPlayer, 0f, 0f);
                            return;
                        }
                    }
                }
                else
                {
                    int num398 = 1;
                    if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
                    {
                        num398 = -1;
                    }
                    float num399 = 8f;
                    float num400 = 0.2f;
                    if (Main.expertMode)
                    {
                        num399 = 9.5f;
                        num400 = 0.25f;
                    }
                    Vector2 vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    float num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num398 * 340) - vector43.X;
                    float num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
                    float num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
                    num403 = num399 / num403;
                    num401 *= num403;
                    num402 *= num403;
                    if (NPC.velocity.X < num401)
                    {
                        NPC.velocity.X = NPC.velocity.X + num400;
                        if (NPC.velocity.X < 0f && num401 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num400;
                        }
                    }
                    else if (NPC.velocity.X > num401)
                    {
                        NPC.velocity.X = NPC.velocity.X - num400;
                        if (NPC.velocity.X > 0f && num401 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num400;
                        }
                    }
                    if (NPC.velocity.Y < num402)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num400;
                        if (NPC.velocity.Y < 0f && num402 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num400;
                        }
                    }
                    else if (NPC.velocity.Y > num402)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num400;
                        if (NPC.velocity.Y > 0f && num402 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num400;
                        }
                    }
                    vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector43.X;
                    num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
                    NPC.rotation = (float)Math.Atan2((double)num402, (double)num401) - 1.57f;
                    if (Main.netMode != 1)
                    {
                        NPC.localAI[1] += 1f;
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
                        {
                            NPC.localAI[1] += 0.5f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
                        {
                            NPC.localAI[1] += 0.75f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
                        {
                            NPC.localAI[1] += 1.5f;
                        }
                        if (Main.expertMode)
                        {
                            NPC.localAI[1] += 1.5f;
                        }
                        if (NPC.localAI[1] > 60f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                        {
                            NPC.localAI[1] = 0f;
                            float num404 = 9f;
                            int damage = 20;
                            int projectile = ModContent.ProjectileType<PermaburnBoltProjectile>();
                            if (Main.expertMode)
                            {
                                damage = 17;
                            }
                            num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
                            num403 = num404 / num403;
                            num401 *= num403;
                            num402 *= num403;
                            vector43.X += num401 * 15f;
                            vector43.Y += num402 * 15f;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), vector43.X, vector43.Y, num401, num402, projectile, damage, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 180f)
                    {
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.TargetClosest(true);
                        NPC.netUpdate = true;
                        return;
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
            if (Main.netMode != 1 && NPC.life <= 0)
            {
                Main.NewText("Fatal mistake, child...", new Color(50, 112, 255));
                Main.NewText("Frigid Elementals are emerging...", new Color(120, 80, 255));
                Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
                Vector2 spawnAt2 = NPC.Center + new Vector2(0f, (float)NPC.height / 4f);
                NPC.NewNPC(NPC.GetSource_Death(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<PermafrostRun>());
                NPC.NewNPC(NPC.GetSource_Death(), (int)spawnAt.X, (int)spawnAt2.Y, ModContent.NPCType<Frigid>());
                NPC.NewNPC(NPC.GetSource_Death(), (int)spawnAt2.X, (int)spawnAt.Y, ModContent.NPCType<Frigid>());
            }
        }

        public override bool PreKill()
        {
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 200, true);
            if (Main.expertMode || Main.rand.Next(2) == 0)
            {
                target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 300, true);
            }
        }
    }
}
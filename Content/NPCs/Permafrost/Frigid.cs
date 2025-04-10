using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.NPCs.Permafrost
{
    [AutoloadBossHead]
    public class Frigid : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frigid Elemental");
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 8000;
            NPC.damage = 20;
            NPC.defense = 10;
            AnimationType = NPCID.Retinazer;
            NPC.knockBackResist = 0f;
            NPC.width = 108;
            NPC.height = 108;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.npcSlots = 15f;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.coldDamage = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.Item110;
            NPC.DeathSound = SoundID.Item30;
            NPC.buffImmune[24] = true;
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
                    if (Main.expertMode)
                    {
                        if (num379 > 300f)
                        {
                            num374 += 0.5f;
                        }
                        if (num379 > 400f)
                        {
                            num374 += 0.5f;
                        }
                        if (num379 > 500f)
                        {
                            num374 += 0.55f;
                        }
                        if (num379 > 600f)
                        {
                            num374 += 0.55f;
                        }
                        if (num379 > 700f)
                        {
                            num374 += 0.6f;
                        }
                        if (num379 > 800f)
                        {
                            num374 += 0.6f;
                        }
                    }
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
                            NPC.ai[3] = 0f;
                        }
                    }
                }
                else if (NPC.ai[1] == 1f)
                {
                    NPC.rotation = num370;
                    float num384 = 12f;
                    if (Main.expertMode)
                    {
                        num384 = 18f;
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
            }
        }


        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = NPC.direction;

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
    }
}
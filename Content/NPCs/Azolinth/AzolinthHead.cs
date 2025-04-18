using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TrelamiumRemastered.Content.Projectiles.Boss.Azolinth;
using TrelamiumRemastered.Content.Items.Azolinth;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered;
using Terraria.GameContent;

namespace TrelamiumRemastered.Content.NPCs.Azolinth
{
    [AutoloadBossHead]
    public class AzolinthHead : ModNPC
    {
        public bool flies = true;
        public bool directional = true;
        public bool SpawnParts = false;
        //--------------------------//
        public float speed = 10f;
        public float turnSpeed = 0.16f;
        //--------------------------//
        public int azoStateAttacks = 0;
        public int azoStateHalfHealth = 0;
        public int azoStatePulsarBeam = 0;

        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Azolinth, Omakron Scourge");
        //}

        public override void SetDefaults()
        {
            NPC.npcSlots = 5f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 6;
            AIType = -1;
            NPC.defense = 30;
            NPC.damage = 300;
            NPC.lifeMax = 300000;
            NPC.HitSound = new SoundStyle("TrelamiumRemastered/Sounds/NPC/AzoHit");
            NPC.DeathSound = new SoundStyle("TrelamiumRemastered/Sounds/NPC/AzoDeath");
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.value = Terraria.Item.buyPrice(1, 0, 0, 0);
            NPC.boss = true;
            NPC.netAlways = true;
            NPC.scale = 1.10f;
            for (int k = 0; k < NPC.buffImmune.Length; k++)
            {
                NPC.buffImmune[k] = true;
            }
            NPC.alpha = 255;
            Music = MusicLoader.GetMusicSlot("TrelamiumRemastered/Sounds/Music/AzolinthTheme");
            //bossBag = mod.ItemType("AzolinthBag");
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "The " + name;
            potionType = ItemID.SuperHealingPotion;
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (player.active && !player.dead)
                {
                    player.GetModPlayer<TrelamiumModPlayer>().azolinthActive = true;
                }
            }
            //bool flagNull = false;
            NPC.localAI[2] += 1f;
            #region Basic Code         
            Lighting.AddLight(NPC.Center, 0f, 0.15f, 0.25f);
            NPC.alpha -= 5;
            if (NPC.alpha < 0)
            {
                NPC.alpha = 0;
            }
            if (Main.player[NPC.target].dead)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (!SpawnParts)
            {
                int Spawned = NPC.whoAmI;
                for (int SpawnPart = 0; SpawnPart < 76; SpawnPart++)
                {
                    int Spawn = 0;
                    int NewSpawnBody = ModContent.NPCType<AzolinthBody>();
                    int NewSpawnTail = ModContent.NPCType<AzolinthTail>();
                    if (SpawnPart >= 0 && SpawnPart < 75)
                    {
                        Spawn = NPC.NewNPC(NPC.GetSource_FromThis(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), NewSpawnBody, NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                    }
                    else
                    {
                        Spawn = NPC.NewNPC(NPC.GetSource_FromThis(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), NewSpawnTail, NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                    }
                    Main.npc[Spawn].realLife = NPC.whoAmI;
                    Main.npc[Spawn].ai[2] = NPC.whoAmI;
                    Main.npc[Spawn].ai[1] = Spawned;
                    Main.npc[Spawned].ai[0] = Spawn;
                    Spawned = Spawn;
                }
                SpawnParts = true;
            }
            #endregion
            if (azoStateAttacks == 0 && ((double)NPC.life < (double)NPC.lifeMax * 1))
            {
                Main.NewText("AZ0-01: Attack Array loaded, Multifire Barrage, Clone Hive, Pulsar Ray", new Color(100, 175, 255));
                azoStateAttacks++;
            }
            if (azoStatePulsarBeam == 0 && ((double)NPC.life < (double)NPC.lifeMax * 0.45))
            {
                Main.NewText("AZ0-02: System low state detected, pulsar beam mode initiated", new Color(80, 135, 255));
                speed = 15f;
                turnSpeed = 0.25f;
                azoStatePulsarBeam++;
            }
            if (azoStateHalfHealth == 0 && ((double)NPC.life < (double)NPC.lifeMax * 0.35))
            {
                Main.NewText("AZ0-03: System critical state detected, rampancy mode initiated", new Color(80, 135, 255));
                speed = 15f;
                turnSpeed = 0.25f;
                azoStateHalfHealth++;
            }
            if (NPC.localAI[2] == 600f)
            {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), ModContent.NPCType<AzoCloneHead>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
            }
            if (NPC.localAI[2] == 200f && ((double)NPC.life < (double)NPC.lifeMax * 0.45))
            {
                SoundEngine.PlaySound(SoundID.Item93, NPC.position);
            }
            if (NPC.localAI[2] == 400f && ((double)NPC.life < (double)NPC.lifeMax * 0.45))
            {
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X, NPC.position.Y, NPC.velocity.X, NPC.velocity.Y, ModContent.ProjectileType<AzolinthPulsarRayProjectile>(), 60, 0f, Main.myPlayer, (float)Main.rand.Next(0, 31), 0f);
                SoundEngine.PlaySound(SoundID.Item73, NPC.position);
            }
            if (NPC.localAI[2] >= 600f)
            {
                NPC.localAI[2] = 0f;
                NPC.localAI[0] = 0f;
            }
            ////////////////////////           
            int num180 = (int)(NPC.position.X / 16f) - 1;
            int num181 = (int)((NPC.position.X + (float)NPC.width) / 16f) + 4;
            int num182 = (int)(NPC.position.Y / 16f) - 1;
            int num183 = (int)((NPC.position.Y + (float)NPC.height) / 16f) + 4;
            if (num180 < 0)
            {
                num180 = 0;
            }
            if (num181 > Main.maxTilesX)
            {
                num181 = Main.maxTilesX;
            }
            if (num182 < 0)
            {
                num182 = 0;
            }
            if (num183 > Main.maxTilesY)
            {
                num183 = Main.maxTilesY;
            }
            bool flag18 = flies;
            if (!flag18)
            {
                for (int num184 = num180; num184 < num181; num184++)
                {
                    for (int num185 = num182; num185 < num183; num185++)
                    {
                        if (Main.tile[num184, num185] != null && ((Main.tile[num184, num185].HasUnactuatedTile && (Main.tileSolid[(int)Main.tile[num184, num185].TileType] || (Main.tileSolidTop[(int)Main.tile[num184, num185].TileType] && Main.tile[num184, num185].TileFrameY == 0))) || Main.tile[num184, num185].LiquidAmount > 64))
                        {
                            Vector2 vector17;
                            vector17.X = (float)(num184 * 16);
                            vector17.Y = (float)(num185 * 16);
                            if (NPC.position.X + (float)NPC.width > vector17.X && NPC.position.X < vector17.X + 16f && NPC.position.Y + (float)NPC.height > vector17.Y && NPC.position.Y < vector17.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.Next(100) == 0 && NPC.behindTiles && Main.tile[num184, num185].HasUnactuatedTile)
                                {
                                    WorldGen.KillTile(num184, num185, true, true, false);
                                }
                                if (Main.netMode != 1 && Main.tile[num184, num185].TileType == 2)
                                {
                                    ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].TileType;
                                }
                            }
                        }
                    }
                }
            }
            if (!flag18)
            {
                Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height);
                int num186 = 1000;
                bool flag19 = true;
                for (int num187 = 0; num187 < 255; num187++)
                {
                    if (Main.player[num187].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            flag19 = false;
                            break;
                        }
                    }
                }
                if (flag19)
                {
                    flag18 = true;
                }
            }
            if (directional)
            {
                if (NPC.velocity.X < 0f)
                {
                    NPC.spriteDirection = 1;
                }
                else if (NPC.velocity.X > 0f)
                {
                    NPC.spriteDirection = -1;
                }
            }
            float num188 = speed;
            float num189 = turnSpeed;
            Vector2 vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
            float num191 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
            float num192 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
            num191 = (float)((int)(num191 / 16f) * 16);
            num192 = (float)((int)(num192 / 16f) * 16);
            vector18.X = (float)((int)(vector18.X / 16f) * 16);
            vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
            num191 -= vector18.X;
            num192 -= vector18.Y;
            float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
            if (NPC.ai[1] > 0f && NPC.ai[1] < (float)Main.npc.Length)
            {
                try
                {
                    vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                    num191 = Main.npc[(int)NPC.ai[1]].position.X + (float)(Main.npc[(int)NPC.ai[1]].width / 2) - vector18.X;
                    num192 = Main.npc[(int)NPC.ai[1]].position.Y + (float)(Main.npc[(int)NPC.ai[1]].height / 2) - vector18.Y;
                }
                catch
                {
                }
                NPC.rotation = (float)System.Math.Atan2((double)num192, (double)num191) + 1.50f;
                num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                int num194 = NPC.width;
                num193 = (num193 - (float)num194) / num193;
                num191 *= num193;
                num192 *= num193;
                NPC.velocity = Vector2.Zero;
                NPC.position.X = NPC.position.X + num191;
                NPC.position.Y = NPC.position.Y + num192;
                if (directional)
                {
                    if (num191 < 0f)
                    {
                        NPC.spriteDirection = 1;
                    }
                    if (num191 > 0f)
                    {
                        NPC.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (!flag18)
                {
                    NPC.TargetClosest(true);
                    NPC.velocity.Y = NPC.velocity.Y + 0.18f;
                    if (NPC.velocity.Y > num188)
                    {
                        NPC.velocity.Y = num188;
                    }
                    if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.5)
                    {
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num189 * 1.8f;
                        }
                        else
                        {
                            NPC.velocity.X = NPC.velocity.X + num189 * 1.8f;
                        }
                    }
                    else if (NPC.velocity.Y == num188)
                    {
                        if (NPC.velocity.X < num191)
                        {
                            NPC.velocity.X = NPC.velocity.X + num189;
                        }
                        else if (NPC.velocity.X > num191)
                        {
                            NPC.velocity.X = NPC.velocity.X - num189;
                        }
                    }
                    else if (NPC.velocity.Y > 4f)
                    {
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num189 * 1f;
                        }
                        else
                        {
                            NPC.velocity.X = NPC.velocity.X - num189 * 1f;
                        }
                    }
                }
                else
                {
                    if (!flies && NPC.behindTiles && NPC.soundDelay == 0)
                    {
                        float num195 = num193 / 45f;
                        if (num195 < 10f)
                        {
                            num195 = 10f;
                        }
                        if (num195 > 20f)
                        {
                            num195 = 20f;
                        }
                        NPC.soundDelay = (int)num195;
                        SoundEngine.PlaySound(SoundID.WormDig, NPC.position);
                    }
                    num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                    float num196 = System.Math.Abs(num191);
                    float num197 = System.Math.Abs(num192);
                    float num198 = num188 / num193;
                    num191 *= num198;
                    num192 *= num198;
                    bool flag21 = false;
                    if (!flag21)
                    {
                        if ((NPC.velocity.X > 0f && num191 > 0f) || (NPC.velocity.X < 0f && num191 < 0f) || (NPC.velocity.Y > 0f && num192 > 0f) || (NPC.velocity.Y < 0f && num192 < 0f))
                        {
                            if (NPC.velocity.X < num191)
                            {
                                NPC.velocity.X = NPC.velocity.X + num189;
                            }
                            else
                            {
                                if (NPC.velocity.X > num191)
                                {
                                    NPC.velocity.X = NPC.velocity.X - num189;
                                }
                            }
                            if (NPC.velocity.Y < num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y + num189;
                            }
                            else
                            {
                                if (NPC.velocity.Y > num192)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y - num189;
                                }
                            }
                            if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && ((NPC.velocity.X > 0f && num191 < 0f) || (NPC.velocity.X < 0f && num191 > 0f)))
                            {
                                if (NPC.velocity.Y > 0f)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y + num189 * 2f;
                                }
                                else
                                {
                                    NPC.velocity.Y = NPC.velocity.Y - num189 * 2f;
                                }
                            }
                            if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && ((NPC.velocity.Y > 0f && num192 < 0f) || (NPC.velocity.Y < 0f && num192 > 0f)))
                            {
                                if (NPC.velocity.X > 0f)
                                {
                                    NPC.velocity.X = NPC.velocity.X + num189 * 2f;
                                }
                                else
                                {
                                    NPC.velocity.X = NPC.velocity.X - num189 * 2f;
                                }
                            }
                        }
                        else
                        {
                            if (num196 > num197)
                            {
                                if (NPC.velocity.X < num191)
                                {
                                    NPC.velocity.X = NPC.velocity.X + num189 * 1.1f;
                                }
                                else if (NPC.velocity.X > num191)
                                {
                                    NPC.velocity.X = NPC.velocity.X - num189 * 1.1f;
                                }
                                if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (NPC.velocity.Y > 0f)
                                    {
                                        NPC.velocity.Y = NPC.velocity.Y + num189;
                                    }
                                    else
                                    {
                                        NPC.velocity.Y = NPC.velocity.Y - num189;
                                    }
                                }
                            }
                            else
                            {
                                if (NPC.velocity.Y < num192)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y + num189 * 1.1f;
                                }
                                else if (NPC.velocity.Y > num192)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y - num189 * 1.1f;
                                }
                                if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (NPC.velocity.X > 0f)
                                    {
                                        NPC.velocity.X = NPC.velocity.X + num189;
                                    }
                                    else
                                    {
                                        NPC.velocity.X = NPC.velocity.X - num189;
                                    }
                                }
                            }
                        }
                    }
                }
                NPC.rotation = (float)System.Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) + 1.57f;
                if (flag18)
                {
                    if (NPC.localAI[0] != 1f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 1f;
                }
                else
                {
                    if (NPC.localAI[0] != 0f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 0f;
                }
                if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) || (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) && !NPC.justHit)
                {
                    NPC.netUpdate = true;
                    return;
                }
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 229, hitDirection, -1f, 30, default(Color), 1f);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AzolinthTrophy>(), 7));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AzolinthBag>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmptyRune>(), 1, 6, 12));
        }

        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedAzolinth)
            {
                Main.NewText("Solar matter creatures are emerging from the distance...", new Color(230, 150, 0));
                Main.NewText("The hallow runs rampant in terror...", new Color(255, 175, 98));
                TrelamiumModWorld.downedAzolinth = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);
            }
        }
        
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.PholiotaGoliath;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.NPCs.PholiotaGoliath
{
    [AutoloadBossHead]
    public class PholiotaGoliathBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pholiota Goliath");
            Main.npcFrameCount[NPC.type] = 10;
        }
        public override void SetDefaults()
        {
            NPC.npcSlots = 7.5f;
            NPC.width = 68;
            NPC.height = 120;
            NPC.aiStyle = -1;
            NPC.defense = 5;
            NPC.damage = 20;
            NPC.lifeMax = 1500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            NPC.boss = true;  
            Music = MusicID.Boss1;
            //bossBag = mod.ItemType("FungorBag");
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "The" + name;
            potionType = ItemID.LesserHealingPotion;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.1f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }
        private bool IsOnPlatform()
        {
            int tileX = (int)(NPC.Bottom.X / 16f);
            int tileY = (int)(NPC.Bottom.Y / 16f);

            Tile tile = Framing.GetTileSafely(tileX, tileY);
            return tile.HasTile && Main.tileSolidTop[tile.TileType];
        }
        private void ShootAt(Player target)
        {
            Vector2 shootFrom = NPC.Center;
            Vector2 direction = (target.Center - shootFrom).SafeNormalize(Vector2.UnitY);
            float projectileSpeed = 6f;

            int type = ModContent.ProjectileType<FungalMushroomBoss>();
            int damage = 10;
            float knockBack = 2f;

            Projectile.NewProjectile(NPC.GetSource_FromAI(), shootFrom, direction * projectileSpeed, type, damage, knockBack, Main.myPlayer);
            SoundEngine.PlaySound(SoundID.Item20, NPC.position);
        }
        public override void AI()
        {
            NPC.ai[2]++;
            Player target = Main.player[NPC.target];
            NPC.TargetClosest();
            if (target.Center.Y > NPC.Center.Y + 10f && IsOnPlatform())
            {
                NPC.position.Y += 5f;
            }

            float speed = 1.5f;
            if (target.Center.X > NPC.Center.X)
                NPC.velocity.X = speed;
            else
                NPC.velocity.X = -speed;
            if (NPC.Center.X < Main.player[NPC.target].Center.X - 2f)
            {
                NPC.direction = 1;
            }
            if (NPC.Center.X > Main.player[NPC.target].Center.X + 2f)
            {
                NPC.direction = -1;
            }
            if (NPC.ai[2] >= 60f)
            {
                ShootAt(target);
                NPC.ai[2] = 0f;
            }
            if (NPC.velocity.Y != 0f)
            {
                NPC.TargetClosest(true);
                NPC.spriteDirection = NPC.direction;
                if (Main.player[NPC.target].Center.X < NPC.position.X && NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.95f;
                }
                else if (Main.player[NPC.target].Center.X > NPC.position.X + (float)NPC.width && NPC.velocity.X < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.95f;
                }
                if (Main.player[NPC.target].Center.X < NPC.position.X && NPC.velocity.X > -5f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                }
                else if (Main.player[NPC.target].Center.X > NPC.position.X + (float)NPC.width && NPC.velocity.X < 5f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                }
            }
            else if (Main.player[NPC.target].Center.Y + 50f < NPC.position.Y && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
            {
                NPC.velocity.Y = -7f;
            }

            NPC.spriteDirection = NPC.direction;
            int num;
            if (NPC.ai[0] == 0f)
            {
                NPC.noTileCollide = false;
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.5f;
                    NPC.ai[1] += 1f;
                    if (NPC.ai[1] > 0f)
                    {
                        if (NPC.life < NPC.lifeMax)
                        {
                            NPC.ai[1] += 0.25f;
                        }
                        if (NPC.life < NPC.lifeMax / 2)
                        {
                            NPC.ai[1] += 0.5f;
                        }
                    }
                    if (NPC.ai[1] >= 50f)
                    {
                        NPC.ai[1] = -20f;
                    }
                    else if (NPC.ai[1] == -1f)
                    {
                        NPC.TargetClosest(true);
                        NPC.velocity.X = (float)(2 * NPC.direction);
                        NPC.velocity.Y = -10.1f;
                        NPC.ai[0] = 1f;
                        NPC.ai[1] = 0f;
                    }
                }
            }
            else if (NPC.ai[0] == 1f) //Ground Pound
            {
                if (NPC.velocity.Y == 0f)
                {
                    SoundEngine.PlaySound(SoundID.Item14, NPC.position);
                    NPC.ai[0] = 0f;
                    for (int num623 = (int)NPC.position.X - 20; num623 < (int)NPC.position.X + NPC.width + 40; num623 += 20)
                    {
                        for (int num624 = 0; num624 < 4; num624 = num + 1)
                        {
                            int num625 = Dust.NewDust(new Vector2(NPC.position.X - 20f, NPC.position.Y + (float)NPC.height), NPC.width + 20, 4, 31, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust3 = Main.dust[num625];
                            dust3.velocity *= 0.2f;
                            num = num624;
                        }
                        int num626 = Gore.NewGore(NPC.GetSource_Death(), new Vector2((float)(num623 - 20), NPC.position.Y + (float)NPC.height - 8f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Gore gore = Main.gore[num626];
                        gore.velocity *= 0.4f;
                    }
                }
                else
                {
                    NPC.TargetClosest(true);
                    if (NPC.position.X < Main.player[NPC.target].position.X && NPC.position.X + (float)NPC.width > Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.5f;
                        NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                    }
                    else
                    {
                        if (NPC.direction < 0)
                        {
                            NPC.velocity.X = NPC.velocity.X - 0.2f;
                        }
                        else if (NPC.direction > 0)
                        {
                            NPC.velocity.X = NPC.velocity.X + 0.2f;
                        }
                        float num627 = 1f;
                        if (NPC.life < NPC.lifeMax)
                        {
                            num627 += 1f;
                        }
                        if (NPC.life < NPC.lifeMax / 2)
                        {
                            num627 += 1f;
                        }
                        if (NPC.life < NPC.lifeMax / 4)
                        {
                            num627 += 1f;
                        }
                        if (NPC.velocity.X < -num627)
                        {
                            NPC.velocity.X = -num627;
                        }
                        if (NPC.velocity.X > num627)
                        {
                            NPC.velocity.X = num627;
                        }
                    }
                }
            }
            if (NPC.target <= 0 || NPC.target == 255 || Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(true);
            }
            int num628 = 3000;
            if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) + Math.Abs(NPC.Center.Y - Main.player[NPC.target].Center.Y) > (float)num628)
            {
                NPC.TargetClosest(true);
                if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) + Math.Abs(NPC.Center.Y - Main.player[NPC.target].Center.Y) > (float)num628)
                {
                    NPC.active = false;
                    return;
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FungorMask>(), 7)); --
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PholiotaGoliathTrophy>(), 7)); 
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<BookOfShrooms>(), ModContent.ItemType<FungalBlade>(), ModContent.ItemType<Lyophylance>(), ModContent.ItemType<MushroomFlail>(), ModContent.ItemType<PholiotaBow>()));
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LivingShroomEmblem>(), 1));
        }
        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedPholiotaGoliath)
            {
                TrelamiumModWorld.downedPholiotaGoliath = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
            }
        }

        //public override void NPCLoot()
        //{
        //    if (Main.rand.Next(10) == 0)
        //    {
        //        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PholiotaGoliathMask"));
        //    }
        //    if (Main.rand.Next(7) == 0)
        //    {
        //        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PholiotaGoliathTrophy"));
        //    }
        //    if (Main.expertMode)
        //    {
        //        npc.DropBossBags();
        //    }
        //    else
        //    {
        //        if (Main.rand.Next(5) == 0)
        //        {
        //            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BookOfShrooms"));
        //        }
        //        if (Main.rand.Next(5) == 0)
        //        {
        //            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FungalBlade"));
        //        }
        //        if (Main.rand.Next(5) == 0)
        //        {
        //            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Lyophylance"));
        //        }
        //        if (Main.rand.Next(5) == 0)
        //        {
        //            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushroomFlail"));
        //        }
        //        if (Main.rand.Next(5) == 0)
        //        {
        //            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PholiotaBow"));
        //        }
        //    }
        //    if (!TrelamiumModWorld.downedPholiotaGoliath)
        //    {
        //        TrelamiumModWorld.downedPholiotaGoliath = true;
        //        if (Main.netMode == NetmodeID.Server)
        //            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
        //    }
        //}
    }
}
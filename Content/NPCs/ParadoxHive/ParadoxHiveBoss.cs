using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TrelamiumRemastered.Content.Items.ParadoxHive;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Projectiles.Boss.ParadoxHive;

namespace TrelamiumRemastered.Content.NPCs.ParadoxHive
{
    [AutoloadBossHead]
    public class ParadoxHiveBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paradox Hive");
            NPCID.Sets.TrailCacheLength[NPC.type] = 3;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
        }
        public override void SetDefaults()
        {
            NPC.width = 70;
            NPC.height = 82;
            NPC.aiStyle = -1;
            NPC.damage = 150;
            NPC.defense = 50;
            NPC.lifeMax = 4000;
            NPC.knockBackResist = 0f;
            NPC.npcSlots = 10f;
            NPC.boss = true;
            NPC.noGravity = true;
            for (int k = 0; k < NPC.buffImmune.Length; k++)
            {
                NPC.buffImmune[k] = true;
            }
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = (float)Item.buyPrice(5, 0, 0, 0);
            //bossBag = mod.ItemType("ParadoxBag");
            Music = MusicLoader.GetMusicSlot("TrelamiumRemastered/Sounds/Music/RepetitiveDesolation");
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "The " + name;
            potionType = ItemID.SuperHealingPotion;
        }
        public override void AI()
        {
            NPC.ai[1]++;
            NPC.ai[2]++;
            NPC.ai[3]++;
            Player player = Main.player[NPC.target];
            if (NPC.ai[1] >= 60) 
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 direction = (Main.player[NPC.target].Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    float speed = 12f;
                    int type = ModContent.ProjectileType<ParadoxLaserProjectile>(); 
                    int damage = 70;
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * speed, type, damage, 1f, Main.myPlayer);
                }

                NPC.ai[1] = 0f;
                NPC.netUpdate = true;
            }
            if (NPC.ai[2] >= 95)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 direction = (Main.player[NPC.target].Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    float speed = 12f;
                    int type = ModContent.ProjectileType<ParadoxMissileProjectile>();
                    int damage = 100;
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * speed, type, damage, 1f, Main.myPlayer);
                }

                NPC.ai[2] = 0f;
                NPC.netUpdate = true;
            }
            if (NPC.ai[3] >= 120)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 direction = (Main.player[NPC.target].Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    float speed = 12f;
                    int type = ModContent.ProjectileType<ParadoxCloneHiveProjectile>();
                    int damage = 100;
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * speed, type, damage, 1f, Main.myPlayer);
                }

                NPC.ai[3] = 0f;
                NPC.netUpdate = true;
            }
            //bool pattern1 = false;
            //bool pattern2 = false;
            //bool pattern3 = false;
            //bool pattern4 = false;
            //bool pattern5 = false;
            NPC.rotation = (NPC.rotation * 8f + NPC.velocity.X * 0.10f) / 10f;
            NPC.TargetClosest(true);
            if (NPC.ai[0] == 0f)
            {
                NPC.velocity.X = NPC.velocity.X * (-NPC.oldVelocity.X * 0.15f);
                if (NPC.velocity.X > 8f)
                {
                    NPC.velocity.X = 8f;
                }
                if (NPC.velocity.X < -8f)
                {
                    NPC.velocity.X = -8f;
                }
            }
            Vector2 vector5 = Main.player[NPC.target].Center - NPC.Center;
            vector5.Y -= 200f;
            if (vector5.Length() > 500f)
            {
                NPC.ai[0] = 1f;
            }
            if (vector5.Length() > 80f)
            {
                float scaleFactor15 = 6f;
                float num1308 = 50f;
                vector5.Normalize();
                vector5 *= scaleFactor15;
                NPC.velocity = (NPC.velocity * (num1308 - 1f) + vector5) / num1308;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxHiveTrophy>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxHiveTrophy>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FragmentedCrystal>(), 1, 11, 15));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<Oblivion>(), ModContent.ItemType<Equinoxx>()));
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxStaff>(), 1));
        }

        public override void OnKill()
        {
            if (!TrelamiumModWorld.downedParadoxHive)
            {
                TrelamiumModWorld.downedParadoxHive = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData); 
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Npc[NPC.type].Value.Width * 0.5f, NPC.height * 0.5f);
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, NPC.gfxOffY);
                Color color = NPC.GetAlpha(drawColor) * ((float)(NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, null, color, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
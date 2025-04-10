using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class EnchantedClam : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enchanted Clam");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.npcSlots = 1.5f;
            NPC.knockBackResist = 0f;
            NPC.damage = 30;
            NPC.lifeMax = 140;
            NPC.rarity = 5;
            NPC.defense = 10;
            NPC.width = 44;
            NPC.height = 24;
            AnimationType = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }
        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0f, 0f, 1.75f);
            NPC.localAI[1] += 1f;
            if (NPC.localAI[1] == 100f)
            {
                float num390 = 10f;
                //float num391 = 0.25f;
                Vector2 vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                float num392 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
                float num393 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector42.Y;
                float num394 = (float)Math.Sqrt((double)(num392 * num392 + num393 * num393));
                num394 = num390 / num394;
                num392 *= num394;
                num393 *= num394;
                float num395 = 8.5f;
                int damage = 30;
                int projectile = ProjectileID.Bubble;
                SoundEngine.PlaySound(SoundID.Item86, NPC.position);
                if (Main.expertMode)
                {
                    num395 = 10f;
                    damage = 20;
                }
                num394 = (float)Math.Sqrt((double)(num392 * num392 + num393 * num393));
                num394 = num395 / num394;
                num392 *= num394;
                num393 *= num394;
                vector42.X += num392 * 15f;
                vector42.Y += num393 * 15f;
                int num1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector42.X, vector42.Y, num392, num393, projectile, damage, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[num1].hostile = true;
                Main.projectile[num1].friendly = false;
                return;
            }
            
            if (NPC.localAI[0] >= 100f)
            {
                NPC.localAI[1] = 0f;
                NPC.localAI[0] = 0f;
            }
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss1)
            {
                return SpawnCondition.OceanMonster.Chance * 0.5f;
            }
            else
            {
                return 0f;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenPearl>(), 2, 1, 3));
        }
    }
}
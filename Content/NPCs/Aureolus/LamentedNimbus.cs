using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Boss.Cumulor;

namespace TrelamiumRemastered.Content.NPCs.Aureolus
{
    public class LamentedNimbus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lamented Nimbus");
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.npcSlots = 10f;
            NPC.knockBackResist = 0f;
            NPC.damage = 20;
            NPC.lifeMax = 100;
            AnimationType = NPCID.AngryNimbus;
            NPC.defense = 5;
            NPC.width = 48;
            NPC.height = 42;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
        }
        public override void AI()
        {
            NPC.noGravity = true;
            NPC.TargetClosest(true);
            float num697 = 6.5f;
            float num698 = 0.50f;
            Vector2 vector90 = new Vector2(NPC.Center.X, NPC.Center.Y);
            float num699 = Main.player[NPC.target].Center.X - vector90.X;
            float num700 = Main.player[NPC.target].Center.Y - vector90.Y - 200f;
            float num701 = (float)Math.Sqrt((double)(num699 * num699 + num700 * num700));
            if (num701 < 20f)
            {
                num699 = NPC.velocity.X;
                num700 = NPC.velocity.Y;
            }
            else
            {
                num701 = num697 / num701;
                num699 *= num701;
                num700 *= num701;
            }
            if (NPC.velocity.X < num699)
            {
                NPC.velocity.X = NPC.velocity.X + num698;
                if (NPC.velocity.X < 0f && num699 > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + num698 * 2f;
                }
            }
            else if (NPC.velocity.X > num699)
            {
                NPC.velocity.X = NPC.velocity.X - num698;
                if (NPC.velocity.X > 0f && num699 < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X - num698 * 2f;
                }
            }
            if (NPC.velocity.Y < num700)
            {
                NPC.velocity.Y = NPC.velocity.Y + num698;
                if (NPC.velocity.Y < 0f && num700 > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + num698 * 2f;
                }
            }
            else if (NPC.velocity.Y > num700)
            {
                NPC.velocity.Y = NPC.velocity.Y - num698;
                if (NPC.velocity.Y > 0f && num700 < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - num698 * 2f;
                }
            }
            if (NPC.position.X + (float)NPC.width > Main.player[NPC.target].position.X && NPC.position.X < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width && NPC.position.Y + (float)NPC.height < Main.player[NPC.target].position.Y && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && Main.netMode != 1)
            {
                NPC.ai[0] += 1f;
                if (NPC.ai[0] > 40f)
                {
                    NPC.ai[0] = 0f;
                    int num702 = (int)(NPC.position.X + 10f + (float)Main.rand.Next(NPC.width - 20));
                    int num703 = (int)(NPC.position.Y + (float)NPC.height + 4f);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), (float)num702, (float)num703, 0f, 5f, ModContent.ProjectileType<LamentRainProjectile>(), 10, 0f, Main.myPlayer, 0f, 0f);
                    return;
                }
            }
        }
    }
}
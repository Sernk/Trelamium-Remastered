using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Azolinth
{
    public class AzolinthBody : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Azolinth, Omakron Scourge");
        }
        public override void SetDefaults()
        {
            NPC.npcSlots = 0.0005f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 6;
            NPC.damage = 80;
            NPC.defense = 80;
            NPC.lifeMax = 300000;
            NPC.HitSound = new SoundStyle("TrelamiumRemastered/Sounds/NPC/AzoHit");
            NPC.DeathSound = new SoundStyle("TrelamiumRemastered/Sounds/NPC/AzoDeath");
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.netAlways = true;
            NPC.scale = 1.10f;
            for (int k = 0; k < NPC.buffImmune.Length; k++)
            {
                NPC.buffImmune[k] = true;
            }
            NPC.dontCountMe = true;
        }
        public override void AI()
        {
            Projectile projectile = Main.projectile[NPC.target];
            if (projectile.penetrate > 10)
            {
                projectile.damage = 1;
            }
            if (projectile.penetrate == -1)
            {
                projectile.damage = 1;
            }
            Lighting.AddLight(NPC.Center, 0f, 0.15f, 0.25f);        
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            NPC.localAI[1] += 1f;
            if (Main.rand.Next(6) == (0))
            {
                if (NPC.localAI[1] == 880f)
                {
                    Vector2 vector103 = new Vector2(NPC.position.X + 20f + (float)Main.rand.Next(NPC.width - 40), NPC.position.Y + 20f + (float)Main.rand.Next(NPC.height - 40));
                    float num797 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector103.X;
                    float num798 = Main.player[NPC.target].position.Y - vector103.Y;
                    num797 += (float)Main.rand.Next(-50, 51);
                    num798 += (float)Main.rand.Next(-50, 51);
                    num798 -= Math.Abs(num797) * ((float)Main.rand.Next(0, 21) * 0.01f);
                    float num799 = (float)Math.Sqrt((double)(num797 * num797 + num798 * num798));
                    float num800 = 12.5f;
                    num799 = num800 / num799;
                    num797 *= num799;
                    num798 *= num799;
                    int damage = 35;
                    num797 *= 1f + (float)Main.rand.Next(-20, 21) * 0.02f;
                    num798 *= 1f + (float)Main.rand.Next(-20, 21) * 0.02f;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), vector103.X, vector103.Y, num797, num798, 592, damage, 0f, Main.myPlayer, (float)Main.rand.Next(0, 31), 0f);
                }
            }
            if (NPC.localAI[1] >= 880f)
            {
                NPC.localAI[1] = 0f;
                NPC.localAI[0] = 0f;
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreKill()
        {
            return false;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 100, hitDirection, -1f, 10, default(Color), 1f);
            }
            if (NPC.life > 0)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 100, hitDirection, -1f, 100, default(Color), 1f);
            }
        }
    }
}
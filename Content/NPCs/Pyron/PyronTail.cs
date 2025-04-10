using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Pyron
{
    public class PyronTail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pyron, the Solar Devourer");
        }
        public override void SetDefaults()
        {
            NPC.npcSlots = 5f;
            NPC.width = 38;
            NPC.height = 38;
            NPC.aiStyle = 6;
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.lifeMax = 22000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.scale = 1.15f;
            NPC.netAlways = true;
            NPC.buffImmune[BuffID.Frostburn] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Burning] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Daybreak] = true;
            NPC.dontCountMe = true;
        }
        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0.5f, 0.3f, 0.1f);
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
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
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 127, hitDirection, -1f, 10, default(Color), 1f);
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Azolinth
{
    public class AzoCloneTail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omakronian Scourge");

        }
        public override void SetDefaults()
        {
            NPC.npcSlots = 0.1f;
            NPC.width = 28;
            NPC.height = 28;
            NPC.aiStyle = 6;
            NPC.damage = 40;
            NPC.defense = 0;
            NPC.lifeMax = 3000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.scale = 0.85f;
            NPC.netAlways = true;
            for (int k = 0; k < NPC.buffImmune.Length; k++)
            {
                NPC.buffImmune[k] = true;
            }
            NPC.dontCountMe = true;
        }
        public override void AI()
        {
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
    }
}
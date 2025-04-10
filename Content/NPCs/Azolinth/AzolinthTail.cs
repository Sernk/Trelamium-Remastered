using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TrelamiumRemastered.Content.NPCs.Azolinth
{
    public class AzolinthTail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Azolinth, Omakron Scourge");
        }
        public override void SetDefaults()
        {
            NPC.npcSlots = 5f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 6;
            NPC.damage = 80;
            NPC.defense = 50;
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
            Lighting.AddLight(NPC.Center, 0f, 0.15f, 0.25f);
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
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, hitDirection, -1f, 10, default(Color), 1f);
            }
        }
    }
}
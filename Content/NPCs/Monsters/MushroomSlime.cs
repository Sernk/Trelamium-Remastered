using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class MushroomSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mushroom Slime");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 1;
            NPC.npcSlots = 1.5f;
            NPC.knockBackResist = 0.95f;
            NPC.damage = 18;
            NPC.lifeMax = 60;
            NPC.defense = 5;
            NPC.width = 32;
            NPC.height = 26;
            AnimationType = 16;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.value = Item.buyPrice(0, 0, 0, 45);
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.5f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Mushroom, 2, 1, 3));
        }
    }
}
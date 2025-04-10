using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class MushroomZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Zombie");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 20;
            NPC.defense = 3;
            NPC.lifeMax = 70;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Terraria.Item.buyPrice(0, 0, 0, 65);
            NPC.knockBackResist = 0.55f;
            NPC.aiStyle = 3;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.45f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Mushroom, 1, 1, 3));
        }
    }
}
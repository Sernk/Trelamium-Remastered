using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class SunFairy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sunblunar Lightning Bug");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Pixie];
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 22;
            NPC.npcSlots = 2f;
            NPC.knockBackResist = 0.8f;
            NPC.damage = 120;
            NPC.lifeMax = 4000;
            NPC.defense = 30;
            NPC.width = 56;
            NPC.height = 50;
            AnimationType = 75;
            NPC.scale = 0.75f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.Pixie;
            NPC.noGravity = true;
            NPC.value = Item.buyPrice(0, 0, 1, 0);
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (TrelamiumModWorld.downedAzolinth)
            {
                return SpawnCondition.Sky.Chance * 0.5f;
            }
            else
            {
                return 0f;
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SublunarFragmentation>(), 2, 1, 2));
        }
    }
}
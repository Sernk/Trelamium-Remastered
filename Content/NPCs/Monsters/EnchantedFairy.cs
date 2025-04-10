using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Tiles.DruidsGarden;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class EnchantedFairy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enchanted Fairy");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Pixie];
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 22;
            NPC.npcSlots = 2f;
            NPC.knockBackResist = 0.8f;
            NPC.damage = 15;
            NPC.lifeMax = 120;
            NPC.defense = 5;
            NPC.width = 30;
            NPC.height = 30;
            AnimationType = 75;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.Pixie;
            NPC.noTileCollide = true;
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
            return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<EnchantedSoilTile>() ? 0.5f : 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NatureEssence>(), 2, 1, 2));
        }
    }
}
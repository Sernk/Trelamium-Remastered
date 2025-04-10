using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;
using TrelamiumRemastered.Content.Tiles.DruidsGarden;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class SludgeBeast : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Alluvial Sludgebeast");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 1;
            NPC.npcSlots = 1.5f;
            NPC.knockBackResist = 0.75f;
            NPC.damage = 30;
            NPC.lifeMax = 120;
            NPC.defense = 10;
            NPC.width = 50;
            NPC.height = 46;
            AnimationType = 16;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.value = Item.buyPrice(0, 0, 1, 80);
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(int)(spawnInfo.SpawnTileX), (int)(spawnInfo.SpawnTileY)].TileType == ModContent.TileType<EnchantedSoilTile>() ? 0.35f : 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NatureEssence>(), 2, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheAncientEdge>(), 30, 1, 1));
        }
    }
}
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.NPCs.Monsters
{
    public class ErodedArmor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eroded Armor");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 25;
            NPC.defense = 3;
            NPC.lifeMax = 120;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = Terraria.Item.buyPrice(0, 0, 0, 65);
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.5f * bossAdjustment);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(ModContent.BuffType<RustPoisoning>(), 100);
            if (Main.expertMode)
            {
                target.AddBuff(ModContent.BuffType<RustPoisoning>(), 200);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.10f;
            }
            if (!Main.hardMode && NPC.downedBoss1)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.25f;
            }
            else
            {
                return 0f;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustyCog>(), 1, 1, 3));
        }
    }
}
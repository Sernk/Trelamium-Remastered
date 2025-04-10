using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;
using TrelamiumRemastered.Content.Items.Pyron;

namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class SymphonyBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag");
            //Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = 8;
            Item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<Aquafinity>(), ModContent.ItemType<AquarianPiccolo>(), ModContent.ItemType<LeviathansClasp>(), ModContent.ItemType<TideOfTheGods>(), ModContent.ItemType<SirensLamentB>()));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DepthStone>(), 1, 8, 22));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RinsBulwark>()));

            //itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<RinsBulwark>(), ModContent.ItemType<AquaticPendant>(), ModContent.ItemType<FuedalHeirloom>());
        }
    }
}
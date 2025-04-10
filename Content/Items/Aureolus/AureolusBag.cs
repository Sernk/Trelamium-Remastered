using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
	public class AureolusBag : ModItem
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
			Item.rare = 2;
			Item.expert = true;
		}

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CumulorMask>(), 7)); - 
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheKingsTear>(), 5));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormStriderBoots>(), 1));

            itemLoot.Add(ItemDropRule.OneFromOptions(1,
               ModContent.ItemType<CumulorsRemnants>(),
               ModContent.ItemType<AerialStrider>(),
               //ModContent.ItemType<NimbusStaff>(), -
               ModContent.ItemType<CloudBuster>()
           ));
        }
	}
}
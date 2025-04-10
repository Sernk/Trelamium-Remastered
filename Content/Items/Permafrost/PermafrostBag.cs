using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Aureolus;
using TrelamiumRemastered.Content.Items.Azolinth;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
	public class PermafrostBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Treasure Bag");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 6;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PermafrostMask>(), 7)); --
            itemLoot.Add(ItemDropRule.OneFromOptions(1,ModContent.ItemType<ThermalCleaver>(), ModContent.ItemType<GlacialFloe>(), ModContent.ItemType<CryotineShard>(),ModContent.ItemType<ColdbloomTome>(), ModContent.ItemType<GlaciersMememto>()));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeltofAlgidity>(), 1));
        }
	}
}
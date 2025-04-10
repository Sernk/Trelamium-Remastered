using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TrelamiumRemastered.Content.Items.Azolinth
{
	public class AzolinthBag : ModItem
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
			Item.rare = 10;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AzolinthTrophy>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmptyRune>(), 1, 6, 12));
        }      
	}
}
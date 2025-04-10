using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Pyron
{
	public class PyronBag : ModItem
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
			Item.rare = 3;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PyronMask>(), 7)); --
            itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<HadesTrident>(), ModContent.ItemType<CombustionRifle>(), ModContent.ItemType<Prevalence>(), ModContent.ItemType<SoliusArk>()));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SolarEmblem>(), 1));
        }
       
	}
}
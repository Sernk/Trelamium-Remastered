using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
	public class MysteriousSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mysterious Seed");
            //Tooltip.SetDefault("Places a Plantera Bulb");
        }

		public override void SetDefaults()
		{
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.rare = 7;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.createTile = TileID.PlanteraBulb;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NatureEssence>(), 10);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
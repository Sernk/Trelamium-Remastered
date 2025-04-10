using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Placeable
{
    public class BlastFurnace : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Blast Furnace");
            //Tooltip.SetDefault("Used for advanced smelting");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.rare = 2;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<BlastFurnaceTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Furnace);
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddIngredient(ItemID.Topaz, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Furnace);
            recipe1.AddIngredient(ItemID.LeadBar, 4);
            recipe1.AddIngredient(ItemID.Chain, 3);
            recipe1.AddIngredient(ItemID.Topaz, 4);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
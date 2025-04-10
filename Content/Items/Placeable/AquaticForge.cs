using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Placeable
{
    public class AquaticForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aquatic Forge");
            //Tooltip.SetDefault("Used for crafted ocean-related gear");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.rare = 4;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<AquaticForgeTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 10);
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.Seashell, 5);
            recipe.AddIngredient(ItemID.Starfish, 3);
            recipe.AddIngredient(ItemID.Sapphire, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
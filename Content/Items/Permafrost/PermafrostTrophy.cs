using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Trophies;
namespace TrelamiumRemastered.Content.Items.Permafrost
{
    public class PermafrostTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Permafrost Trophy");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 50000;
            Item.rare = 3;
            Item.createTile = ModContent.TileType<PermafrostTrophyTile>();
            Item.placeStyle = 0;
        }
    }
}
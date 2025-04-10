using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Trophies;

namespace TrelamiumRemastered.Content.Items.Azolinth
{
    public class AzolinthTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Azolinth Trophy");
            //Tooltip.SetDefault("");
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
            Item.createTile = ModContent.TileType<AzolinthTrophyTile>();
            Item.placeStyle = 0;
        }
    }
}
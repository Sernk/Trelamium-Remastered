using System;
using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.DruidsGarden;

namespace TrelamiumRemastered
{
    public class BiomeTileCounterSystem : ModSystem
    {
        public static int ZoneDruidsGarden = 0;

        public override void ResetNearbyTileEffects()
        {
            ZoneDruidsGarden = 0;                     
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            ZoneDruidsGarden = tileCounts[ModContent.TileType<EnchantedSoilTile>()];
        }
    }
}
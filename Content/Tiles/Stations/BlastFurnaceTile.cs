using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TrelamiumRemastered.Content.Tiles.Stations
{
    public class BlastFurnaceTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Blast Furnace");
            AddMapEntry(new Color(255, 255, 255), CreateMapEntryName());
            DustType = 6;
            AdjTiles = new int[]
            {
            TileID.Furnaces
            };

        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
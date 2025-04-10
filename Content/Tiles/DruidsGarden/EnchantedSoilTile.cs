using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TrelamiumRemastered.Content.Tiles.DruidsGarden
{
	public class EnchantedSoilTile : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            DustType = 0;
            MineResist = 1f;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(30, 225, 75), CreateMapEntryName());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

        //public override int SaplingGrowthType(ref int style)
        //{
        //    style = 0;
        //    return mod.TileType("LotuswoodSaplingTile");
        //}
    }
}
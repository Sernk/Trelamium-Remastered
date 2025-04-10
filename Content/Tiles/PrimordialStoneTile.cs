using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TrelamiumRemastered.Content.Tiles
{
    public class PrimordialStoneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            DustType = 31;
            MineResist = 0.5f;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(180, 130, 75), CreateMapEntryName());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
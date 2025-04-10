using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Tiles.DruidsGarden
{
    public class AlluviumOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = 74;
            MineResist = 1f;
            MinPick = 65;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(126, 75, 57), CreateMapEntryName());
        }

        //public override void KillMultiTile(int i, int j, int frameX, int frameY)
        //{
        //    var source = Main.LocalPlayer.GetSource_ItemUse(Main.LocalPlayer.HeldItem);
        //    Item.NewItem(source, i * 16, j * 16, 48, 48, ModContent.ItemType<AlluviumChunk>(), 1, false, 0, false, false);
        //}

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

    }
}
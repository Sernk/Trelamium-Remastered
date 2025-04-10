using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles;

namespace TrelamiumRemastered.Content.Items
{
    public class AncientFossil : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Ancient Fossil");
        //}
        public override void SetDefaults()
        {
            Item.rare = 3;
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 0);
            Item.createTile = ModContent.TileType<PrimordialStoneTile>();
        }
    }
}
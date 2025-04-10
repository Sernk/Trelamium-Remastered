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
    public class Agate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Agate");
            //Tooltip.SetDefault("'The Groundmole might find this useful...'");
        }
        public override void SetDefaults()
        {
            Item.rare = -12;
            Item.width = 14;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 25);
            Item.createTile = ModContent.TileType<AgateTile>();
        }
    }
}
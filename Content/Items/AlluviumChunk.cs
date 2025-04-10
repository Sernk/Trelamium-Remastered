using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.DruidsGarden;

namespace TrelamiumRemastered.Content.Items
{
    public class AlluviumChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Alluvium Chunk");
        }
        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 14;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 30);
            Item.createTile = ModContent.TileType<AlluviumOreTile>();
        }
    }
}
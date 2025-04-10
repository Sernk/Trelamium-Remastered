using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class BrassChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Brass Chunk");
            //Tooltip.SetDefault("'Contains little shards of brass'");
        }
        public override void SetDefaults()
        {
            Item.rare = 8;
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 3, 75);
        }
    }
}
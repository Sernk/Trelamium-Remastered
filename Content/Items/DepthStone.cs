using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class DepthStone : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Depth Stone");
        //}
        public override void SetDefaults()
        {
            Item.rare = 8;
            Item.width = 24;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 30);
        }
    }
}
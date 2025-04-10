using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class GalaticCore : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Galatic Core");
        //}
        public override void SetDefaults()
        {
            Item.rare = 10;
            Item.width = 24;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
        }
    }
}
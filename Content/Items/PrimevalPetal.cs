using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class PrimevalPetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primeval Petal");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
        }
    }
}
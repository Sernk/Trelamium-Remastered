using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class RustyCog : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rusty Cog");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.rare = 1;
            Item.width = 20;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
        }
    }
}
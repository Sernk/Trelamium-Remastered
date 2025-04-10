using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class UnknownTechnology : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Unknown Technology");
            //Tooltip.SetDefault("It has symbols of the Omakron planet on it...");
        }
        public override void SetDefaults()
        {
            Item.rare = 9;
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 3, 50, 0);
        }
    }
}
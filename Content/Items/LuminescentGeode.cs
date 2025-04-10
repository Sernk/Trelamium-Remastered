using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class LuminescentGeode : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Luminescent Geode");
            //Tooltip.SetDefault("'Filled with strange glowing fluid'");
        }
        public override void SetDefaults()
        {
            Item.rare = 9;
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 75);
        }
    }
}
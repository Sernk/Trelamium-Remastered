using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class MurkyGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Murky Gel");
            //Tooltip.SetDefault("'The Groundmole might find this useful...'");
        }
        public override void SetDefaults()
        {
            Item.rare = -12;
            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
        }
    }
}
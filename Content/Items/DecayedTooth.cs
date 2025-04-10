using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class DecayedTooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Decayed Tooth");
            //Tooltip.SetDefault("An unusual material..."
            //    + "\nMaybe it can be used to craft advanced potions.");
        }
        public override void SetDefaults()
        {
            Item.rare = 1;
            Item.width = 18;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 30);
        }
    }
}
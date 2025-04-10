using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class AerialEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aerial Essence");
            //Tooltip.SetDefault("'Holds the melodies of harpies and banshees screeches'");
        }
        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 5, 75);
        }
    }
}
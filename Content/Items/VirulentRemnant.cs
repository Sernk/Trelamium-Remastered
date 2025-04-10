using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class VirulentRemnant : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Virulent Remnant");
            //Tooltip.SetDefault("'Remnants of the tainted'");
        }
        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 6, 0);
        }
    }
}
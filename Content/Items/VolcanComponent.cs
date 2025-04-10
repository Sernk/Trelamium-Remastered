using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class VolcanComponent : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Volcan Component");
            //Tooltip.SetDefault("'Witholds highly acidic fluids...'");
        }
        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 3, 75, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(81, 255, 240);
                }
            }
        }
    }
}
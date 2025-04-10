using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class FragmentedCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fragmented Crystal");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.rare = 10;
            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 1, 25, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(230, 150, 0);
                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class EuropanSingularity : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Europan Singularity");
        //    Tooltip.SetDefault("'Colder than permafrost...'");
        //}
        public override void SetDefaults()
        {
            Item.rare = 9;
            Item.width = 18;
            Item.height = 14;
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
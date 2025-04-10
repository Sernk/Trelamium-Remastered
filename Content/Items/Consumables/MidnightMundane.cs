using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Consumables
{
    public class MidnightMundane : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Midnight Mundane");
            //Tooltip.SetDefault("Heals 250 health");
        }
        public override void SetDefaults()
        {
            Item.potion = true;
            Item.rare = 0;
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.useAnimation = 20;

            Item.useTime = 20;
            Item.useStyle = 2;
	        Item.healLife = 250;
            Item.UseSound = SoundID.Item3;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(242, 68, 180);
                }
            }
        }
    }
}
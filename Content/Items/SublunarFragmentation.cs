using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TrelamiumRemastered.Content.Items
{
    public class SublunarFragmentation : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sublunar Fragmentation");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 11));
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.rare = 8;
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
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
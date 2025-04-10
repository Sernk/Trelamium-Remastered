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
    public class NatureEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nature Essence");
            //Tooltip.SetDefault("");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 5, 30);
        }
        public override void GrabRange(Player player, ref int grabRange)
        {
            grabRange *= 3;
        }
    }
}
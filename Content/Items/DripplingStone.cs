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
    public class DripplingStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Drippling Stone");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.rare = 1;
            Item.width = 24;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 1, 30);
        }
    }
}
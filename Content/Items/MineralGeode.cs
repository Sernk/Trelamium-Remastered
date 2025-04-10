using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TrelamiumRemastered.Content.Items
{
    public class MineralGeode : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mineral Geode");
            //Tooltip.SetDefault("Contains an abundance of minerals"
            //    + "\nCan probably be used in an extractinator");
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
        }

        public override void ExtractinatorUse(int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (Main.rand.Next(10) == 0)
            {
                resultType = ModContent.ItemType<AncientFossil>();
                if (Main.rand.Next(5) == 0)
                {
                    resultStack += Main.rand.Next(5);
                }
            }
            if (NPC.downedBoss2 && Main.rand.Next(10) == 0)
            {
                resultType = ModContent.ItemType<AlluviumChunk>();
                if (Main.rand.Next(3) == 0)
                {
                    resultStack += Main.rand.Next(10);
                }
            }
        }
    }
}

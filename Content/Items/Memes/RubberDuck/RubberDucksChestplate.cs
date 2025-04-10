using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Memes.RubberDuck
{
    [AutoloadEquip(EquipType.Body)]
    public class RubberDucksChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rubber Duck's Chestplate");
            //Tooltip.SetDefault("Great for impersoning... ducks?");
        }

        public override void SetDefaults()
        {
            Item.vanity = true;
            Item.width = 24;
            Item.height = 20;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
            Item.rare = 8;
        }
    }
}
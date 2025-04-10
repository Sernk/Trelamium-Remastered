using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
    public class StormStriderBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Storm Strider Boots");
            //Tooltip.SetDefault("Allows the player to run super fast, allows flight"
            //   + "\nIncreases jump height and movement speed greatly"
            //   + "\nGrants immunity to fall damage"
            //   + "\nWhen under 30% of your maximum health your movement speed is boosted tremendously");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 2;
            Item.expert = true;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 70, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += 6.75f;
            player.moveSpeed += 0.10f;
            player.rocketBoots += 5;
            player.noFallDmg = true;

            if (player.statLife <= (player.statLifeMax2 * 0.30f))
            {
                player.moveSpeed += 2f;
            }
        }
    }
}
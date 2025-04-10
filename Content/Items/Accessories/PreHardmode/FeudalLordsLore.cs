using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class FeudalLordsLore : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lore of the Great Fuedal Lord");
            //Tooltip.SetDefault("'The Fedual lords passage..'"
            //+ "\nWater-based enemies become friendly and will deal damage to other enemies."
            //+ "\nBeing submerged in liquid will grant the player with an aquamarine barrier, which will protect you and kill enemies."
            //+ "\nThe three sirens will fight for you.");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Blazing Runestone", "-- Mythic Accessory --");
            line.OverrideColor = new Color(252, 228, 99);
            tooltips.Add(line);
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 8;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrelamiumModPlayer>().sirenLore = true;
            if (player.wet)
            {
                player.GetModPlayer<TrelamiumModPlayer>().aquamarineBarrier = true;
            }
        }
    }
}
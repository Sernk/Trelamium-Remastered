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
    public class FungiRoot : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Fungi Root");
            //Tooltip.SetDefault("'Raiga's spirit lies within this...'"
            //+ "\nAllows the player to transform into a cluster of fungus"
            //+ "\nThe fungus will absorb damage and reflect the damage taken on your next attack."
            //+ "\nTransformation only lasts 5 seconds and takes 5 minutes to recharge");
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
            player.GetModPlayer<TrelamiumModPlayer>().fungiRoot = true;
        }
    }
}
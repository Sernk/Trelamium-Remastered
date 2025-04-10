using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Items.Accessories.Hardmode
{
    public class BlazingRunestone : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Blazing Runestone");
            //Tooltip.SetDefault("Taking damage tremendously increases your movement speed"
            //    + "\nMelee weapons inflict 'Solar God's Torment'"
            //    + "\nIncreases maximum health by 50"
            //    + "\nEnemies have a small chance to COMBUST into embers, COMBUSTing will deal massive dmage"
            //    + "\nHaha yes, Vortex I added your meme. ^^^");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Blazing Runestone", "-- Mythic Accessory --");
            line.OverrideColor = new Color(252, 228, 99);
            tooltips.Add(line);
        }

        public override void SetDefaults()
        {
            Item.height = 30;
            Item.width = 30;
            Item.rare = 8;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 35, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 50;
            player.GetModPlayer<TrelamiumModPlayer>().blazingStone = true;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Symphony 
{
    public class RinsBulwark : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rin's Bulwark");
            //Tooltip.SetDefault("Grants immunity to Knockback, Siren's Lament, and illusion/darkness based debuffs"
            //    + "\nAllows the player to swim, breathe water, and befriend ocean creatures"
            //    + "\nIncreases damage by 20% when in water, melee weapons are imbued with Siren's Lament");
        }
        public override void SetDefaults()
        {
            Item.height = 30;
            Item.width = 30;
            Item.rare = 8;
            Item.expert = true;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 25, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.accFlipper = true;
            player.gills = true;
            player.waterWalk = true;
            player.buffImmune[ModContent.BuffType<SirensLament>()] = true;
            if (player.wet)
            {
                player.GetDamage(DamageClass.Melee) += 0.2f;
                player.GetDamage(DamageClass.Ranged) += 0.2f;
                player.GetDamage(DamageClass.Magic) += 0.2f;
                player.GetDamage(DamageClass.Throwing) += 0.2f;
                player.GetDamage(DamageClass.Summon) += 0.2f;
            }
        }
    }
}
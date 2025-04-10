using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Memes;

namespace TrelamiumRemastered.Content.Items.Memes.RubberDuck
{
    public class Duckbringer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("The Ultimate Ultra-Mega Godly Duckbringer");
            //Tooltip.SetDefault("Creates the 'Super Sonic Special' Attack");
        }
        public override void SetDefaults()
        {
            Item.damage = 5000;
            Item.crit = 50;
            Item.rare = 8;
            Item.width = 58;
            Item.height = 64;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 1;
            Item.knockBack = 15f;
            Item.shootSpeed = 25f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<RubberDuckProjectile>();
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(242, 68, 180);
                }
            }
        }
    }
}
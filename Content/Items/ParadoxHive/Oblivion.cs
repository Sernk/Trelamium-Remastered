using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.ParadoxHive
{
    public class Oblivion : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Oblivion");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 350;
            Item.crit = 24;
            Item.rare = 10;
            Item.width = 62;
            Item.height = 62;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 8.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 80, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<OblivionBeamProjectile>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(164, 43, 46);
                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.PholiotaGoliath
{
    public class Lyophylance : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lyophylance");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 5;
            Item.knockBack = 6.5f;
            Item.shootSpeed = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 70, 0);
            Item.UseSound = SoundID.Item73;
            Item.shoot = ModContent.ProjectileType<LyophylanceProjectile>();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
    public class GlaciersMememto : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glacier's Mememto");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.crit = 4;
            Item.rare = 6;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 6;
            Item.useTime = 6;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.shoot = ModContent.ProjectileType<GlaciersMementoProjectile>();
            Item.UseSound = SoundID.Item1;
        }
    }
}
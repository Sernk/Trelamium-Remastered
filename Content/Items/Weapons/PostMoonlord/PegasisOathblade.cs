using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class PegasisOathblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pegasi's Oathblade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 86;
            Item.crit = 12;
            Item.rare = 6;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 8f;
            Item.shootSpeed = 25f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 20, 75, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<PegasusOathProjectile>();
        }
    }
}
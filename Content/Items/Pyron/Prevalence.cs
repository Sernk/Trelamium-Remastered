using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Pyron
{
    public class Prevalence : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Prevalence");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 24f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<PrevalenceArrowProjectile>();
            return true;
        }
    }
}
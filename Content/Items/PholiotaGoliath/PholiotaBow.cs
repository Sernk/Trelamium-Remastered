using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.PholiotaGoliath
{
    public class PholiotaBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pholiota Bow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 28;
            Item.height = 46;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 4f;
            Item.shootSpeed = 8f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 25);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<MycelialArrowProjectile>();
            return true;
        }
    }
}
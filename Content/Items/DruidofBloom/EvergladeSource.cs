using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.DruidofBloom
{
    public class EvergladeSource : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Everglade Source");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 4;
            Item.rare = 5;
            Item.width = 62;
            Item.height = 62;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 12, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.Leaf;  //ModContent.ProjectileType<EverbloomLeafProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
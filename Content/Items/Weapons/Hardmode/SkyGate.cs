using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class SkyGate : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sky Gate");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.rare = 8;
            Item.width = 116;
            Item.height = 112;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 5;
            Item.shootSpeed = 90f;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ProjectileID.SkyFracture;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(30);
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 95f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.SkyFracture, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
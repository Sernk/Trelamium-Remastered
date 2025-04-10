using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Boss.Cumulor.Friendly;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
    public class CumulorsRemnants : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cumulor's Remnants");
            //Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.rare = 2;
            Item.width = 28;
            Item.height = 30;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 5;
            Item.mana = 10;
            Item.shootSpeed = 12.5f;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 0, 0);
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<MagicCloudProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(45));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
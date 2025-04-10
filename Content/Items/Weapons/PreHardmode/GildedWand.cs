using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class GildedWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pearl Wand");
            // Tooltip.SetDefault("Sprays a wave of bubbles");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.rare = 6;
            Item.width = 50;
            Item.height = 50;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.mana = 10;
            Item.shootSpeed = 20f;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ProjectileID.Bubble;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 4;
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GoldenPearl>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
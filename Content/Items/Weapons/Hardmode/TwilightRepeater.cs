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
    public class TwilightRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Twilight Repeater");
            /* Tooltip.SetDefault("'The Nighttide...'"
                + "\nFires arrows in an even arc"); */
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.rare = 5;
            Item.width = 26;
            Item.height = 56;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 5;
            Item.shootSpeed = 18f;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 12, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
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
            recipe.AddIngredient(ModContent.ItemType<TwilightDust>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
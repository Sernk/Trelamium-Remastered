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
    public class OnyxPump : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Onyx Pump Shotgun");
            // Tooltip.SetDefault("Fires a spread of bullets");
        }
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 38;
            Item.height = 20;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 7, 50, 0);
            Item.UseSound = SoundID.Item36;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
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
    public class UnicornCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Unicorn Cannon");
            /* Tooltip.SetDefault("The Ultimate combination of rainbows and unicorns!"
                + "\nHas three different attack types: Crystal Bullet, Crystal, and Rocket"
                + "\nCrystal bullet mode fires a burst of crystal bullets"
                + "\nCrystal mode fires pink bolts that explode into smaller bolts on impact"
                + "\nRocket mode rapidly fires rockets"
                + "\nEvery shot will switch modes"
                + "\nAlthough this has mutliple different attack styles, this weapon uses bullets."); */
        }
        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 70;
            Item.height = 28;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            Item.UseSound = SoundID.Item36;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int modeSwitch = Main.rand.Next(3);
            if (modeSwitch == 0)
            {
                int numberProjectiles = 3 + Main.rand.Next(2);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalBullet, damage, knockback, player.whoAmI);
                }
            }
            if (modeSwitch == 1)
            {
                type = ProjectileID.CrystalPulse;
                return true;
            }
            if (modeSwitch == 2)
            {
                type = ProjectileID.RocketI;
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HeavyRifle>());
            recipe.AddIngredient(ItemID.UnicornHorn, 4);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
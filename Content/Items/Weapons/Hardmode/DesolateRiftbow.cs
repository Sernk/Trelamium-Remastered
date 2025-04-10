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
    public class DesolateRiftbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desolate Riftbow");
            // Tooltip.SetDefault("Creates rifts which arrows will appear from");
        }
        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float abovePlayer = player.position.Y + 200;
            float playerPosition = abovePlayer + player.direction;
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Projectile.NewProjectile(source, playerPosition, abovePlayer, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
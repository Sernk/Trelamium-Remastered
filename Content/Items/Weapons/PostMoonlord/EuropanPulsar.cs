using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class EuropanPulsar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Europan Pulsar");
            // Tooltip.SetDefault("Fires an arc of Artic Beams");
        }
        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.crit = 8;
            Item.rare = 10;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 40f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(5, 0, 0, 0);
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
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<ArticBeamProjectile>(), damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VenusPulsar>());
            recipe.AddIngredient(ModContent.ItemType<EuropanSingularity>(), 8);
            recipe.AddIngredient(ModContent.ItemType<EmptyRune>(), 2);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(81, 255, 240);
                }
            }
        }
    }
}
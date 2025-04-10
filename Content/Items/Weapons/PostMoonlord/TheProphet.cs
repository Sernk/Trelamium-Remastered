using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class TheProphet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Prophet");
            /* Tooltip.SetDefault("'The Prophet's vison...'"
                + "\nFires a burst of prophet arrows which home enemies"
                + "\nProphet arrows also combust on impact"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.crit = 4;
            Item.rare = 9;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 38f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(8, 0, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(16));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<GalaticDaggerProjectile>(), damage, knockback, player.whoAmI);
            }

            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AngelsArk>());
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 10);
            recipe.AddIngredient(ModContent.ItemType<QuantumComponent>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(230, 150, 0);
                }
            }
        }
    }
}
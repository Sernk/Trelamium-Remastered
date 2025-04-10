using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class Colaria : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Colaria");
            /* Tooltip.SetDefault("'The True Omega...'"
                + "\nFires a massive barrage of rainbow bolts that split into more bolts"
                + "\nRainbow bolts explode into exospheres on impact"
                + "\nRainbow exospheres create a large area of damage"
                + "\nMelee attacks inflict Radiant Euphoria, which is very deadly"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.crit = 10;
            Item.rare = -12;
            Item.expert = true;
            Item.width = 70;
            Item.height = 70;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = 1;
            Item.knockBack = 8.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(5, 0, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<RadiantBoltProjectile>();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<RadiantEuphoria>(), 200);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(65));
                float scale = 1.225f - (Main.rand.NextFloat() * .35f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OmegaNE>());
            recipe.AddIngredient(ModContent.ItemType<OmegaExcalibur>());
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 10);
            recipe.AddIngredient(ModContent.ItemType<QuantumComponent>(), 7);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
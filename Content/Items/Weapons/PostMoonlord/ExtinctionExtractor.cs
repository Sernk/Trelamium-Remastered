using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;
using TrelamiumRemastered.Content.Items.Weapons.Hardmode;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class ExtinctionExtractor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Extinction Extractor");
            /* Tooltip.SetDefault("'The scourge of living energy...'"
                + "\nFires an arc of crystal rays that will split into bolts"
                + "\nCrystal bolts home enemies and inflict Fractured"
                + "\nFractured cuts enemy defense in half, and occasionally drains health"
                + "\nReleases crystal spirits on enemy death"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 102;
            Item.crit = 12;
            Item.rare = 10;
            Item.width = 66;
            Item.height = 66;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 5f;
            Item.shootSpeed = 25f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(2, 75, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<CrystalRayProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3;
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
            recipe.AddIngredient(ModContent.ItemType<CreationClaymore>());
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddIngredient(ItemID.FragmentNebula, 8);
            recipe.AddIngredient(ItemID.LunarBar, 10);
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
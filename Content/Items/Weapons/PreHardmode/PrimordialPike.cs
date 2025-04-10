using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;
namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class PrimordialPike : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primordial Pike");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 48;
            Item.height = 48;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 6f;
            Item.shootSpeed = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
            Item.shoot = ModContent.ProjectileType<PrimordialPikeProjectile>();
            Item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 12);
            recipe.AddIngredient(ItemID.AntlionMandible, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
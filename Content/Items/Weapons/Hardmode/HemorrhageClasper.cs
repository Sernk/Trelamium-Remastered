using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HemorrhageClasper : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hemorrhage Clasper");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.crit = 8;
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
            Item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            Item.shoot = ModContent.ProjectileType<HemorrhageClasperProjectile>();
            Item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VirulentRemnant>(), 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
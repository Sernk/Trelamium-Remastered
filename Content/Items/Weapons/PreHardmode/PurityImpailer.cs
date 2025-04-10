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
    public class PurityImpailer : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Purity Impailer");
            // Tooltip.SetDefault("Impails and poisons your foes");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 14f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            Item.shoot = ModContent.ProjectileType<PurityImpailerProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RichMahogany, 25);
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.AddIngredient(ItemID.Stinger, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
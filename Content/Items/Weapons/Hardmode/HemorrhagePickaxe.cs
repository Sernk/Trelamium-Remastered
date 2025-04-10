using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HemorrhagePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hemorrhage Pickaxe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 5;
            Item.width = 34;
            Item.height = 34;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.pick = 155;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 4, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VirulentRemnant>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
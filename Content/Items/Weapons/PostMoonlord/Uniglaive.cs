using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Weapons.Hardmode;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class Uniglaive : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Uniglaive");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.crit = 4;
            Item.rare = 10;
            Item.width = 94;
            Item.height = 104;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 1;
            Item.knockBack = 7.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.IceSickle;
            Item.value = Terraria.Item.buyPrice(0, 75, 0, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Archlight>());
            recipe.AddIngredient(ItemID.FragmentSolar, 4);
            recipe.AddIngredient(ItemID.FragmentNebula, 4);
            recipe.AddIngredient(ItemID.FragmentVortex, 4);
            recipe.AddIngredient(ItemID.FragmentStardust, 4);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
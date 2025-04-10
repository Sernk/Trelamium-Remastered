using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class QuantumComponent : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Universal Quantum Component");
            //Tooltip.SetDefault("'Your determination has taken you far...'"
            //+ "\nUsed to craft upgrades of most weapons"
            //+ "\nAlso used to craft mechanical-based items");
        }
        public override void SetDefaults()
        {
            Item.rare = -12;
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ModContent.ItemType<AerialEssence>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 10);
            recipe.AddIngredient(ModContent.ItemType<DripplingStone>(), 10);
            recipe.AddIngredient(ModContent.ItemType<NatureEssence>(), 10);
            recipe.AddIngredient(ModContent.ItemType<TwilightDust>(), 10);
            recipe.AddIngredient(ModContent.ItemType<VirulentRemnant>(), 10); //Crimson
            recipe.AddIngredient(ModContent.ItemType<SoundPrism>(), 10);
            recipe.AddIngredient(ModContent.ItemType<MurkyGel>(), 10);
            recipe.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 10);
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            Recipe recipe1 = CreateRecipe(5);
            recipe1.AddIngredient(ModContent.ItemType<AerialEssence>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<Aquamarine>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<DripplingStone>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<NatureEssence>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<TwilightDust>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 10); //Corruption
            recipe1.AddIngredient(ModContent.ItemType<SoundPrism>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<MurkyGel>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<DepthStone>(), 10);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.Register();
        }
    }
}
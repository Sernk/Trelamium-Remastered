using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class CGWR : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("C.G.W.R");
            // Tooltip.SetDefault("''The Cosmic Gamma Whale's retribution...'");
        }
        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.crit = 8;
            Item.rare = 10;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 6;
            Item.useTime = 6;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 40f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(8, 0, 0, 0);
            Item.UseSound = SoundID.Item36;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyRune>(), 5);
            recipe.AddIngredient(ModContent.ItemType<QuantumComponent>());
            recipe.AddIngredient(ItemID.SDMG);
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
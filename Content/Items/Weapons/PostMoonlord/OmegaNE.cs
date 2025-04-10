using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class OmegaNE : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omega Night's Edge");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.crit = 24;
            Item.rare = 10;
            Item.width = 86;
            Item.height = 96;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 1;
            Item.knockBack = 8.5f;
            Item.shootSpeed = 20f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 80, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<OmegaNightsEdgeProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TrueNightsEdge);
            recipe.AddIngredient(ItemID.BrokenHeroSword); 
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.FragmentSolar, 4);
            recipe.AddIngredient(ItemID.FragmentNebula, 4);
            recipe.AddIngredient(ItemID.FragmentVortex, 4);
            recipe.AddIngredient(ItemID.FragmentStardust, 4);
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
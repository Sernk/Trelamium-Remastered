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
    public class HyrdaBurst : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hydra Burst");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.rare = 8;
            Item.width = 66;
            Item.height = 42;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.shootSpeed = 18f;
            Item.knockBack = 2.5f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 20, 0, 0);
            Item.shoot = ModContent.ProjectileType<HydraBurstProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PhoenixBlaster);
            recipe.AddIngredient(ModContent.ItemType<PrimefuryShard>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(244, 140, 0);
                }
            }
        }
    }
}
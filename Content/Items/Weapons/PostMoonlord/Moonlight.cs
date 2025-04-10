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
    public class Moonlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Moonlight");
            // Tooltip.SetDefault("'Someone once told me certain weapons can be very powerful if used correctly...'");
        }

        public override void SetDefaults()
        {
            Item.damage = 95;
            Item.crit = 4;
            Item.rare = 10;
            Item.width = 54;
            Item.height = 56;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Throwing;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 40, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<MoonlightProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
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
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
    public class WaningReaper : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Waning Reaper");
            /* Tooltip.SetDefault("Fires moon scythes that will split into 4 green scythes"
                + "\nGreen scythes heal the player on enemy contact"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.crit = 14;
            Item.rare = 10;
            Item.width = 54;
            Item.height = 56;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = 1;
            Item.knockBack = 6.5f;
            Item.shootSpeed = 25f;
            Item.DamageType = DamageClass.Throwing;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<ReaperScytheProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Moonlight>());
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(230, 150, 0);
                }
            }
        }
    }
}
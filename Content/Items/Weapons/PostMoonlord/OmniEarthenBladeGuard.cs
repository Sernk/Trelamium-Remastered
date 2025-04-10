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
    public class OmniEarthenBladeGuard : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omni-Earthen Blade Guardian");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.crit = 16;
            Item.rare = 10;
            Item.width = 90;
            Item.height = 90;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 8.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 75, 0, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Scorchia>());
            recipe.AddIngredient(ItemID.FragmentSolar, 5); 
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Weapons.Hardmode;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class RainbowChaingun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rainbow Chaingun");
            /* Tooltip.SetDefault("'The Ultimate combination of weapons'"
                + "\nFires a small burst of radiant bullets"
                + "\nRadiant bullets will explode on enemy contact"
                + "\nFire rate will speed up overtime"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.rare = 10;
            Item.width = 74;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 5;
            Item.shootSpeed = 20f;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(5, 50, 0, 0);
            Item.shoot = ModContent.ProjectileType<RainbowChaingunProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnicornCannon>());
            recipe.AddIngredient(ItemID.RainbowGun);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
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
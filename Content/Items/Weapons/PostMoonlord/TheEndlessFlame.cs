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
    public class TheEndlessFlame : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Endless Flame");
            // Tooltip.SetDefault("Fires a barrage hellfire");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 400;
            Item.rare = 8;
            Item.width = 28;
            Item.height = 30;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.useStyle = 5;
            Item.mana = 10;
            Item.shootSpeed = 8f;
            Item.knockBack = 1.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 80, 0, 0);
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<EndlessFlameProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CursedFlames);
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
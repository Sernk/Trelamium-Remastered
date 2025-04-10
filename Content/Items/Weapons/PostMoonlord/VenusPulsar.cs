using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
{
    public class VenusPulsar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Venus Volcan");
            // Tooltip.SetDefault("Fires volcan acid arrows");
        }
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.crit = 8;
            Item.rare = 10;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 40f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 95, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<VenusVolcanArrowProjectile>();
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VolcanComponent>(), 8);
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
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Ambergris : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("The Ambergris");
            //Tooltip.SetDefault("");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 7;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 20f;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<AmbergrisProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SeaEssence>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}

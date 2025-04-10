using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class TwilightScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Twilight Scepter");
            // Tooltip.SetDefault("Fires twilight beam that inflicts 'Arc of Blight'");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.rare = 5;
            Item.width = 60;
            Item.height = 60;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 14;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 35, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<TwilightBeamProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TwilightDust>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
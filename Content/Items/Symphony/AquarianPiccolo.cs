using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class AquarianPiccolo : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquarian Piccolo");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.rare = 6;
            Item.width = 42;
            Item.height = 18;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 12;
            Item.shootSpeed = 12f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 30, 0);
            Item.UseSound = new SoundStyle("TrelamiumRemastered/Sounds/Item/AquarianPiccolo");
            Item.shoot = ModContent.ProjectileType<AquarianPiccoloProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 12);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}
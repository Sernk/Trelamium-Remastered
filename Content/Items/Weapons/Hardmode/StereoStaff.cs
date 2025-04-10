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
    public class StereoStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Stereo Staff");
            // Tooltip.SetDefault("Fires a fast moving transversal wave");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.rare = 7;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 14;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<SoundWaveProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoPrism>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
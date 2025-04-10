using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class LuminescentPulsar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Luminescent Pulsar");
            // Tooltip.SetDefault("Fires a granite pulse which will overload enemies");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 30;
            Item.height = 64;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 15f;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    type = ModContent.ProjectileType<EnergyPulseProjectile>();
        //    return true;
        //}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
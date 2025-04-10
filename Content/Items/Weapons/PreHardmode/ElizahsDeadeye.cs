using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ElizahsDeadeye : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Elizah's Deadeye");
            /* Tooltip.SetDefault("Elizah's trump card, the undefeated deadeye."
                + "\nOccasionally fires Blighted rounds which inflict temperamental pain"
                + "\nThere is a chance the deadeye will fire 6 bullets at once dealing massive damage"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 60;
            Item.height = 30;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item36;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.Boomstick);
            recipe.AddIngredient(ItemID.FlareGun);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.PlatinumBar, 10);
            recipe1.AddIngredient(ItemID.Chain, 2);
            recipe1.AddIngredient(ItemID.Boomstick);
            recipe1.AddIngredient(ItemID.FlareGun);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
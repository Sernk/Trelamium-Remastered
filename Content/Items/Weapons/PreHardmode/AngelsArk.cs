using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AngelsArk : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("The Angel's Ark");
            //Tooltip.SetDefault("'The Angel from above.'"
            //    + "\nFires darklight arrows which fragment into shadow energy"
            //    + "\nShadow energy homes at enemies and inflicts Darklight");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<DarklightArrowProjectile>();
            return true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeesKnees);
            recipe.AddIngredient(ItemID.DemonBow);
            recipe.AddIngredient(ItemID.MoltenFury);
            recipe.AddIngredient(ModContent.ItemType<AncientWraithbow>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.BeesKnees);
            recipe1.AddIngredient(ItemID.TendonBow);
            recipe1.AddIngredient(ItemID.MoltenFury);
            recipe1.AddIngredient(ModContent.ItemType<AncientWraithbow>());
            recipe1.AddTile(TileID.DemonAltar);
            recipe1.Register();
        }
    }
}
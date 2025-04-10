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
    public class CombustionBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Combustion Blade");
            //Tooltip.SetDefault("Hitting enemies causes a combustion doing massive damage");
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.crit = 4;
            Item.rare = 5;
            Item.width = 70;
            Item.height = 70;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 7.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        //public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        //{
        //    target.AddBuff(BuffID.Daybreak, 200);
        //    Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0, ModContent.ProjectileType<CombustionProjectile>(), item.damage, item.knockBack, item.owner);
        //}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
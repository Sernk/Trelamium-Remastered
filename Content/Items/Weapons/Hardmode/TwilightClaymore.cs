using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;
using TrelamiumRemastered.Content.Projectiles.Dusts;
namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class TwilightClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Twilight Eclipse");
            // Tooltip.SetDefault("striking enemies creates twilight energy");
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.crit = 10;
            Item.rare = 5;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 1;
            Item.knockBack = 5.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TwilightDust>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int index = 0; index < numberProjectiles; ++index)
            {
                int type = ModContent.ProjectileType<MeteorProjectile>();
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = Item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f;
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;
                int ProIndex = Projectile.NewProjectile(player.GetSource_FromThis(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, hit.Damage, damageDone, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Pyron
{
    public class HadesTrident : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Trident of Hades");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(3570);
            Item.damage = 35;
            Item.crit = 4;
            Item.rare = 6;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 12;
            Item.useTime = 10;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.mana = 17;
            Item.shoot = 295;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 75, 0);
            Item.UseSound = SoundID.Item73;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ProjectileID.InfernoFriendlyBolt;
            int num = 3 + Main.rand.Next(2);
            for (int i = 0; i < num; i++)
            {
                Vector2 vector = new Vector2((float)((double)((Entity)player).position.X + (double)((Entity)player).width * 0.5 + (double)(Main.rand.Next(201) * -((Entity)player).direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)((Entity)player).position.X)), (float)((double)((Entity)player).position.Y + (double)((Entity)player).height * 0.5 - 600.0));
                vector.X = (float)(((double)vector.X + (double)((Entity)player).Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector.Y -= 100 * i;
                float num2 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                if ((double)num3 < 0.0)
                {
                    num3 *= -1f;
                }
                if ((double)num3 < 20.0)
                {
                    num3 = 20f;
                }
                float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                float num5 = ((ModItem)this).Item.shootSpeed / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                float num8 = num6 + (float)Main.rand.Next(-40, 41) * 0.02f;
                float num9 = num7 + (float)Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, vector.X, vector.Y, num8, num9, type, damage, knockback, Main.myPlayer, 0f, (float)Main.rand.Next(5));
            }
            return false;
        }
    }
}
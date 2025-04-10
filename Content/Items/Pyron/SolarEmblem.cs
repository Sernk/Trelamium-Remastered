using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Pyron
{
    public class SolarEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Solar Emblem");
            /* Tooltip.SetDefault("Taking damage releases solar flares"
            + "\nIncreases movement speed by 18%"); */
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 10;
            Item.expert = true;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.18f;
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.immune)
                {
                    int num18 = 1;
                    if (Main.rand.Next(3) == 0)
                    {
                        num18++;
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                        num18++;
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                        num18++;
                    }
                    for (int num19 = 0; num19 < num18; num19++)
                    {
                        float speedX = (float)Main.rand.Next(-55, 56) * 0.10f;
                        float speedY = (float)Main.rand.Next(-55, 56) * 0.10f;
                        int Index = Projectile.NewProjectile(Item.GetSource_FromThis(), player.position.X, player.position.Y, speedX, speedY, ProjectileID.GreekFire1, 25, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[Index].hostile = false;
                        Main.projectile[Index].friendly = true;
                        Main.projectile[Index].timeLeft = 45;
                    }
                }
            }
        }
    }
}
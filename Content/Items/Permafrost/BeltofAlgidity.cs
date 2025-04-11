using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
    public class BeltofAlgidity : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Belt of Algidity");
            //Tooltip.SetDefault("Oh hey, it actually works now."
            //+ "\nAllows the player to dash"
            //+ "\nDashing into enemies will release a burst of glacial energy"
            //+ "\nIncreases damage reduction by 20%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 10;
            Item.expert = true;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrelamiumModPlayer>().algidityBelt = true;
            player.GetModPlayer<BeltofAlgidityPlayer>().DashAccessoryEquipped = true;
            player.dash = 1;
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.immune)
                {
                    int num18 = 1;
                    if (Main.rand.Next(10) == 0)
                    {
                        num18++;
                    }
                    for (int num19 = 0; num19 < num18; num19++)
                    {
                        float speedX = (float)Main.rand.Next(-55, 56) * 0.10f;
                        float speedY = (float)Main.rand.Next(-55, 56) * 0.10f;
                        int Index = Projectile.NewProjectile(Item.GetSource_FromThis(), player.position.X, player.position.Y, speedX, speedY, ModContent.ProjectileType<ThermalFloeProjectile>(), 30, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[Index].hostile = false;
                        Main.projectile[Index].friendly = true;
                        Main.projectile[Index].timeLeft = 30;
                    }
                }
            }
        }
    }
}
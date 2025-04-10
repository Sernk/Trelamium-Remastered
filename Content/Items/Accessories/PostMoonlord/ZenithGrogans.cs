using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PostMoonlord
{
    public class ZenithGrogans : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Zenith Grogans");
            //Tooltip.SetDefault("Allows the player to run insanely fast"
            //   + "\nAllows water walking, water breathing, lava immunity, and ice mobility"
            //   + "\nGetting struck creates demon scythes above you"
            //   + "\nWhen under 10% of your maximum health your movement speed is boosted tremendously");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 11;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 70, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += 10f;
            player.iceSkate = true;
            player.waterWalk = true;
            player.gills = true;
            player.lavaImmune = true;
            player.noFallDmg = true;
            if (player.statLife <= (player.statLifeMax2 * 0.10f))
            {
                player.moveSpeed += 5f;
            }
            if (player.immune)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    if (Main.netMode != 1 && Main.rand.Next (4) ==(0))
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            float x = player.position.X + (float)Main.rand.Next(-400, 400);
                            float y = player.position.Y - (float)Main.rand.Next(500, 800);
                            Vector2 vector = new Vector2(x, y);
                            float num13 = player.position.X + (float)(player.width / 2) - vector.X;
                            float num14 = player.position.Y + (float)(player.height / 2) - vector.Y;
                            num13 += (float)Main.rand.Next(-100, 101);
                            int num15 = 23;
                            float num16 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
                            num16 = (float)num15 / num16;
                            num13 *= num16;
                            num14 *= num16;
                            int num17 = Projectile.NewProjectile(Item.GetSource_FromThis(), x, y, num13, num14, ProjectileID.DemonScythe, 50, 5f, player.whoAmI, 0f, 0f);
                            Main.projectile[num17].ai[1] = player.position.Y;
                        }
                    }
                }
            }
        }
    }
}
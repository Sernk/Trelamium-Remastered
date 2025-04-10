using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class HydraBurstProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hydra Burst");
            Main.projFrames[Projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 66;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            Projectile.ai[0] += 1f;
            int num2 = 0;
            if (Projectile.ai[0] >= 100f)
            {
                num2++;
            }
            if (Projectile.ai[0] >= 200f)
            {
                num2++;
            }
            if (Projectile.ai[0] >= 300f)
            {
                num2++;
            }
            int num3 = 24;
            int num4 = 6;
            Projectile.ai[1] += 1f;
            bool flag = false;
            if (Projectile.ai[1] >= (float)(num3 - num4 * num2))
            {
                Projectile.ai[1] = 0f;
                flag = true;
            }
            Projectile.frameCounter += 1 + num2;
            if (Projectile.frameCounter >= 4)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= 6)
                {
                    Projectile.frame = 0;
                }
            }
            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = num3 - num4 * num2;
                if (Projectile.ai[0] != 1f)
                {
                    SoundEngine.PlaySound(SoundID.Item114, Projectile.position);
                }
            }
            if (Projectile.ai[1] == 1f && Projectile.ai[0] != 1f)
            {
                Vector2 vector2 = Vector2.UnitX * 24f;
                vector2 = vector2.RotatedBy((double)(Projectile.rotation - 1.57079637f), default(Vector2));
                Vector2 value = Projectile.Center + vector2;
                for (int i = 0; i < 2; i++)
                {
                    int num5 = Dust.NewDust(value - Vector2.One * 8f, 16, 16, 244, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f, 100, default(Color), 1f);
                    Main.dust[num5].velocity *= 0.66f;
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].scale = 1.4f;
                }
            }
            if (flag && Main.myPlayer == Projectile.owner)
            {
                bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
                if (flag2)
                {
                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
                    Vector2 vector3 = vector;
                    Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
                    if (player.gravDir == -1f)
                    {
                        value2.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector3.Y;
                    }
                    Vector2 vector4 = Vector2.Normalize(value2);
                    if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
                    {
                        vector4 = -Vector2.UnitY;
                    }
                    vector4 *= scaleFactor;
                    if (vector4.X != Projectile.velocity.X || vector4.Y != Projectile.velocity.Y)
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = vector4;
                    int num6 = ModContent.ProjectileType<HydraSpitProjectile>();
                    float scaleFactor2 = 14f;
                    int num7 = 7;
                    for (int j = 0; j < 2; j++)
                    {
                        vector3 = Projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
                        Vector2 vector5 = Vector2.Normalize(Projectile.velocity) * scaleFactor2;
                        vector5 = vector5.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
                        if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
                        {
                            vector5 = -Vector2.UnitY;
                        }
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), vector3.X, vector3.Y, vector5.X, vector5.Y, num6, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    }
                }
                else
                {
                    Projectile.Kill();
                }
            }
            Projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - Projectile.Size / 2f;
            Projectile.rotation = Projectile.velocity.ToRotation() + num;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)Math.Atan2((double)(Projectile.velocity.Y * (float)Projectile.direction), (double)(Projectile.velocity.X * (float)Projectile.direction));
            //float num54 = 18f;
            //int num55 = 0;
        }
    }
}
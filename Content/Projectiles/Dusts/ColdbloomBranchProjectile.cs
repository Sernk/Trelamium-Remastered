using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class ColdbloomBranchProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Coldbloom Branch");
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 30;
            Projectile.extraUpdates = 7;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            //int num3 = 0;
            int num20 = 20;
            for (int i = 0; i < num20; i++)
            {
                Vector2 vector2 = Vector2.Normalize(Projectile.velocity) * new Vector2((float)Projectile.width / 2f, (float)Projectile.height) * 0.75f * 0.5f;
                vector2 = vector2.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + Projectile.Center;
                Vector2 vector3 = vector2 - Projectile.Center;
                int num21 = Dust.NewDust(vector2 + vector3, 0, 0, 113, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num21].noGravity = true;
                Main.dust[num21].noLight = true;
                Main.dust[num21].velocity = Vector2.Normalize(vector3) * 3f;
            }
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item114, Projectile.position);
            int num3 = 0;
            int num20 = 72;
            for (int i = 0; i < num20; i++)
            {
                Vector2 vector2 = Vector2.Normalize(Projectile.velocity) * new Vector2((float)Projectile.width / 2f, (float)Projectile.height) * 0.75f * 0.5f;
                vector2 = vector2.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + Projectile.Center;
                Vector2 vector3 = vector2 - Projectile.Center;
                int num21 = Dust.NewDust(vector2 + vector3, 0, 0, 113, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num21].noGravity = true;
                Main.dust[num21].noLight = true;
                Main.dust[num21].velocity = Vector2.Normalize(vector3) * 3f;
            }
            int num229 = 8;
            int[] array = new int[num229];
            int num230 = 0;
            if (num230 > 1)
            {
                for (int num232 = 0; num232 < 100; num232 = num3 + 1)
                {
                    int num233 = Main.rand.Next(num230);
                    int num234;
                    for (num234 = num233; num234 == num233; num234 = Main.rand.Next(num230))
                    {
                    }
                    int num235 = array[num233];
                    array[num233] = array[num234];
                    array[num234] = num235;
                    num3 = num232;
                }
            }
            Vector2 vector10 = new Vector2(-1f, -1f);
            for (int num236 = 0; num236 < num230; num236 = num3 + 1)
            {
                Vector2 value9 = Main.npc[array[num236]].Center - Projectile.Center;
                value9.Normalize();
                vector10 += value9;
                num3 = num236;
            }
            vector10.Normalize();
            for (int num237 = 0; num237 < num229; num237 = num3 + 1)
            {
                float scaleFactor = (float)Main.rand.Next(8, 15);
                Vector2 vector11 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector11.Normalize();
                if (num230 > 0)
                {
                    vector11 += vector10;
                    vector11.Normalize();
                }
                vector11 *= scaleFactor;
                if (num230 > 0)
                {
                    num3 = num230;
                    num230 = num3 - 1;
                    vector11 = Main.npc[array[num230]].Center - Projectile.Center;
                    vector11.Normalize();
                    vector11 *= scaleFactor;
                }
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector11.X, vector11.Y, ModContent.ProjectileType<ColdbloomPetalProjectile>(), (int)((double)Projectile.damage * 0.7), Projectile.knockBack * 0.7f, Projectile.owner, 0f, 0f);
                num3 = num237;
            }
        }
    }
}
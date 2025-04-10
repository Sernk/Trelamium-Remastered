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
    public class Scorchia : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scorchia");
            /* Tooltip.SetDefault("Hitting enemies greatly decreases their defense and shows meteors"
                + "\nIf the enemy has no defense, they will be set ablaze"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 68;
            Item.crit = 10;
            Item.rare = 6;
            Item.width = 66;
            Item.height = 90;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 6.5f;
            Item.shootSpeed = 10.75f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.defense == 0)
            {
                target.AddBuff(BuffID.Daybreak, 200);
                target.AddBuff(BuffID.OnFire, 200);
                target.AddBuff(BuffID.Burning, 200);
            }
            target.defense /= 3;
            int numberProjectiles = 4;
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
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CombustionBlade>());
            recipe.AddIngredient(ModContent.ItemType<EquinoxArk>());
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
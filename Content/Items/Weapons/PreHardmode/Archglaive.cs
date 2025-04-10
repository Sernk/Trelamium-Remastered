using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Archglaive : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Archglaive");
            /* Tooltip.SetDefault("Fires clones on swing"
                + "\nClones impale enemies and inflict shadowflame"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 60;
            Item.height = 56;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
        //    int numberProjectiles = 3;
        //    for (int i = 0; i < numberProjectiles; i++)
        //    {
        //        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
        //        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<ProphetArrowProjectile>(), damage, knockBack, player.whoAmI);
        //    }

        //    return false;
        //}
    }
}
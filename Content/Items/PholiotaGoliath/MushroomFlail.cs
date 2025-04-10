using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.PholiotaGoliath
{
    public class MushroomFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fungus Flail");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.crit = 4;
            Item.height = 10;
            Item.value = Item.sellPrice(2, 0, 0, 0);
            Item.rare = 1;
            //Item.noMelee = true;
            Item.useStyle = 5;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.knockBack = 7.5F;
            Item.scale = 1.1F;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<FungusFlailProjectile>();
            Item.shootSpeed = 25f;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
        }
    }
}
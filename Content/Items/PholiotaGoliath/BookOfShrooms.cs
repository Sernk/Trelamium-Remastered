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
    public class BookOfShrooms : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Book of Shrooms");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.rare = 1;
            Item.width = 28;
            Item.height = 30;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 5;
            Item.mana = 8;
            Item.shootSpeed = 12.5f;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 65, 30);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<FungalMushroomMagicProjectile>();
        }
    }
}
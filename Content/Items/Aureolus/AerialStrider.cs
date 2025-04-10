using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Boss.Cumulor.Friendly;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
    public class AerialStrider : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aerial Strider");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 64;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item99;
            Item.shoot = ModContent.ProjectileType<CloudCannonProjectile>();
        }
    }
}
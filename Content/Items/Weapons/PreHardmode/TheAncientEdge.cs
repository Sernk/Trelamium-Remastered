using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class TheAncientEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Ancient Edge");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 12;
            Item.rare = 5;
            Item.width = 52;
            Item.height = 72;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 1;
            Item.knockBack = 5f;
            Item.shootSpeed = 8.75f;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.DamageType = DamageClass.Melee;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item1;
            //item.shoot = ModContent.ProjectileType<EarthCluster>();
        }
    }
}
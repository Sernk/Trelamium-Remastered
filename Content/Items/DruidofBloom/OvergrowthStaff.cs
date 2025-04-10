using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.DruidofBloom
{
    public class OvergrowthStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Overgrowth Staff");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.rare = 5;
            Item.width = 50;
            Item.height = 50;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.mana = 12;
            Item.shootSpeed = 12f;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ProjectileID.Leaf;
            //item.shoot = mod.ProjectileType("OvergrowthStaffProjectile");
        }
    }
}
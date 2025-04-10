using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class AbyssSpire : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Abyssal Spire");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.rare = 5;
            Item.width = 60;
            Item.height = 60;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 14;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<AbyssalSpireProjectile>();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
    public class CryotineShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cryoxis Shard");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.rare = 6;
            Item.width = 28;
            Item.height = 30;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = 5;
            Item.mana = 10;
            Item.shootSpeed = 18f;
            Item.knockBack = 1.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item73;
            Item.shoot = ModContent.ProjectileType<CryoxisShardProjectile>();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;
namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class FalconStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Falcon Staff");
            // Tooltip.SetDefault("Summons an osprey to fight for you");
        }
        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.rare = 8;
            Item.width = 40;
            Item.height = 44;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.mana = 10;
            Item.shootSpeed = 18f;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<OspreyMinionProjectile>();
        }
    }
}
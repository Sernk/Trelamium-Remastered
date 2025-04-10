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
    public class ApparitionStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Apparition Staff");
            // Tooltip.SetDefault("Summons a shadowflame apparition to fight for you");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.rare = 6;
            Item.width = 70;
            Item.height = 70;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.mana = 12;
            Item.shootSpeed = 18f;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<ShadowflameApparitionProjectile>();
        }
    }
}
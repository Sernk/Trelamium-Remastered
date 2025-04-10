using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class JungleEagle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jungle Eagle");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.rare = 3;
            Item.width = 38;
            Item.height = 20;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = 5;
            Item.reuseDelay = 8;
            Item.shootSpeed = 18f;
            Item.knockBack = 2.5f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item40;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
    }
}
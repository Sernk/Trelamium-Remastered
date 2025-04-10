using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Pyron
{
    public class CombustionRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Combustion Rifle");
            //Tooltip.SetDefault("Uses darts for ammo");
        }
        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 64;
            Item.height = 32;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            Item.UseSound = SoundID.Item99;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Dart;
        }
    }
}
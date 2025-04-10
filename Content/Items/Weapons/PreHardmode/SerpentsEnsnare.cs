using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class SerpentsEnsnare : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Serpent's Ensnare");
            // Tooltip.SetDefault("What the hel-... what the heckk is this?");
        }
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 56;
            Item.height = 26;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item11;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
    }
}
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Zombow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Zombow");
            // Tooltip.SetDefault("'Trelamium Meme #37'");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 30;
            Item.height = 64;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 5;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
    }
}
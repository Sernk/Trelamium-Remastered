using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class GildedWraithbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gilded Wraithbow");
            /* Tooltip.SetDefault("'The Glory from Above...'"
                + "\nTransforms arrows into blighted arrows"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 30, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
    }
}
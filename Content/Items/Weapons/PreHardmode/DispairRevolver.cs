using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class DispairRevolver : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desolate's Lens");
            // Tooltip.SetDefault("Uses darts for ammo");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 38;
            Item.height = 18;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item98;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Dart;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}
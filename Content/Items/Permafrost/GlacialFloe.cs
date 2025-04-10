using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
    public class GlacialFloe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glacial Floe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 46;
            Item.crit = 8;
            Item.rare = 6;
            Item.width = 30;
            Item.height = 54;
            Item.useAnimation = 12;
            Item.useTime = 4;
            Item.reuseDelay = 14;
            Item.useStyle = 5;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 28f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.IceSickle, damage, knockback, player.whoAmI);
            return true;
        }
    }
}
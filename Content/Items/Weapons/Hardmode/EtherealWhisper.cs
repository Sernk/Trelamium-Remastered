using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class EtherealWhisper : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ethereal Whisper");
            /* Tooltip.SetDefault("Casts a small short-lived barrier at the point of your cursor"
                + "\nIf an enemy is in the barrier's bounds they will lose heal rapidly"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 95;
            Item.crit = 10;
            Item.rare = 8;
            Item.width = 64;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 28f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PhantomBarrierProjectile>();
            Item.value = Terraria.Item.buyPrice(0, 40, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpectreBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
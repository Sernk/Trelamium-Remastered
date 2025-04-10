using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AncientBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Warblade");
            // Tooltip.SetDefault("Creates on ancient sickles on enemy hit");
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 38;
            Item.height = 20;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(ItemID.Cobweb, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int projectileIndex = Projectile.NewProjectile(Item.GetSource_FromThis(), Main.MouseWorld.X + 1, Main.MouseWorld.Y, -.001f, 0, ModContent.ProjectileType<AncientSickleProjectile>(), Item.damage, Item.knockBack, Item.playerIndexTheItemIsReservedFor);
        }
    }
}
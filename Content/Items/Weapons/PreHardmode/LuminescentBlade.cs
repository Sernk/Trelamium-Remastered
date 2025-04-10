using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class LuminescentBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Luminescent Blade");
            // Tooltip.SetDefault("Striking enemies creates a granite fluid geyser");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 5.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 3, 75, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int type = ModContent.ProjectileType<GraniteGeyserProjectile>();
            Projectile.NewProjectile(Item.GetSource_FromThis(), target.position.X, target.position.Y, target.width, target.height, type, hit.Damage, damageDone, player.whoAmI);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
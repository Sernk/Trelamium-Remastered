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
    public class HemorrhageBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hemorrhage Blade");
            // Tooltip.SetDefault("Fires a slicing carnage wave");
        }
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 8f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 6, 75, 0);
            Item.UseSound = SoundID.Item1;
            //item.shoot = ModContent.ProjectileType<CarnageWaveProjectile>();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Ichor, 800);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VirulentRemnant>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;
using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class Archlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Archlight");
            /* Tooltip.SetDefault("Creates blighted energy that fragments on contact"
                + "\nMelee attacks inflict 'Blighted'"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.crit = 12;
            Item.rare = 6;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 8f;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 24, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<BlightedEnergyProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Archglaive>());
            recipe.AddIngredient(ItemID.BreakerBlade);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Blighted>(), 400);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ErodedBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eroded Blade");
            // Tooltip.SetDefault("Inflicts 'Rust Poisoning' on enemy hit");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 34;
            Item.height = 34;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 1;
            Item.knockBack = 5.5f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<RustPoisoning>(), 120);
        }
    }
}
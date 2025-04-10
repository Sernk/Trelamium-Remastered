using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class FrostboundBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frostbound Blade");
            // Tooltip.SetDefault("Melee attacks inflict frostburn");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 10;
            Item.rare = 1;
            Item.width = 50;
            Item.height = 50;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 30, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 200);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 10);
            recipe.AddIngredient(ItemID.GoldBroadsword);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.IceBlock, 10);
            recipe1.AddIngredient(ItemID.PlatinumBroadsword);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
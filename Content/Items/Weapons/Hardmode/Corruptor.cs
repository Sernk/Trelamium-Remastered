using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class Corruptor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Corruptor");
            /* Tooltip.SetDefault("Fires cursed flames"
                + "\nMelee attacks inflict Cursed Inferno for a long period of time"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.crit = 10;
            Item.rare = 4;
            Item.width = 42;
            Item.height = 42;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.CursedFlameFriendly;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.CursedInferno, 800);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltBar, 18);
            recipe.AddIngredient(ItemID.CursedFlame, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.PalladiumBar, 18);
            recipe1.AddIngredient(ItemID.CursedFlame, 8);
            recipe1.AddIngredient(ItemID.SoulofNight, 6);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
    }
}
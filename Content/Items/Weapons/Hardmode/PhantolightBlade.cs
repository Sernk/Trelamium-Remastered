using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class PhantolightBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Phantolight Blade");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.crit = 12;
            Item.rare = 8;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
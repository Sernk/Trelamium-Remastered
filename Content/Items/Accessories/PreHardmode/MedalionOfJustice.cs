using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class MedalionOfJustice : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Medalion of Justice");
            //Tooltip.SetDefault("Increases melee damage by 15% and critical strike chance by 8%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 3;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Melee) += 8;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class RedSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Red Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases critical strike chance by 5%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 2;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ItemID.Gel, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
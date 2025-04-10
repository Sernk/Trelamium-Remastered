using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class BlueSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Blue Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases damage by 5%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 0;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.jumpBoost = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
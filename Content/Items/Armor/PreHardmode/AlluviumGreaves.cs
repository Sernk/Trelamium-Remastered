using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Legs)]

    public class AlluviumGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Alluvium Greaves");
            //Tooltip.SetDefault("Increases movement speed by 12%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 7;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.12f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlluviumBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
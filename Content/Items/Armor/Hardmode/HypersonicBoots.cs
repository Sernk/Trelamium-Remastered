using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Armor.Hardmode
{
    [AutoloadEquip(EquipType.Legs)]

    public class HypersonicBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hypersonic Boots");
            //Tooltip.SetDefault("Increases movement speed by 25%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 7;
            Item.defense = 14;
            Item.value = Terraria.Item.buyPrice(0, 2, 75, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoPrism>(), 12);
            recipe.AddTile(ModContent.TileType<SoundConversatorTile>());
            recipe.Register();
        }
    }
}
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
    [AutoloadEquip(EquipType.Body)]

    public class HypersonicChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hypersonic Chestguard");
            //Tooltip.SetDefault("Increases life regeneration by 14%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 7;
            Item.defense = 20;
            Item.value = Terraria.Item.buyPrice(0, 2, 75, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 14;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoPrism>(), 20);
            recipe.AddTile(ModContent.TileType<SoundConversatorTile>());
            recipe.Register();
        }
    }
}
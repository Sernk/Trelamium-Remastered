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
    [AutoloadEquip(EquipType.Body)]

    public class LuminescentChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Luminescent Chestplate");
            //Tooltip.SetDefault("Increases max minions by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 1;
            Item.defense = 6;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Body)]

    public class FrostboundChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frostbound Chestplate");
            //Tooltip.SetDefault("Increases life regeneration by 5");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 1;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 5;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemID.WoodBreastplate);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
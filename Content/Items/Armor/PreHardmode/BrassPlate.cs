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

    public class BrassPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Brass Armor Plate");
            //Tooltip.SetDefault("Increases thrown critical strike chance by 4%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 85, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassChunk>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
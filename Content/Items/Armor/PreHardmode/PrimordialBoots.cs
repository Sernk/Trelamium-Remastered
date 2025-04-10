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

    public class PrimordialBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primordial Cuisses");
            //Tooltip.SetDefault("Increases movement speed by 5%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 2;
            Item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 10);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
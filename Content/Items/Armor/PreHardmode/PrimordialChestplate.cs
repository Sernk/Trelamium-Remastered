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

    public class PrimordialChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primordial Chestplate");
            //Tooltip.SetDefault("Increases ranged critical strike chance by 4%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 35, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Ranged) += 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 14);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
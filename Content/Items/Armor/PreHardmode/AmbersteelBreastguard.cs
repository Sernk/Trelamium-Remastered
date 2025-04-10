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

    public class AmbersteelBreastguard : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ambersteel Breastguard");
            //Tooltip.SetDefault("Increases thrown critical strike chance by 8%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 8;
            Item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 8;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmbersteelAlloy>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
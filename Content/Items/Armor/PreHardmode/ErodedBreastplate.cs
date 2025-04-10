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

    public class ErodedBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Eroded Breastplate");
            //Tooltip.SetDefault("Increases critical strike chance by 4%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 6;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 4;
            player.GetCritChance(DamageClass.Magic) += 4;
            player.GetCritChance(DamageClass.Ranged) += 4;
            player.GetCritChance(DamageClass.Throwing) += 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
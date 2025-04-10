using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Head)]

    public class AlluviumMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Alluvium Mask");
            //Tooltip.SetDefault("Increases magic damage by 10%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 7;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<AlluviumBreastplate>() && legs.type == ModContent.ItemType<AlluviumGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.10f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Three leaves will revolve around you, protecting you\nWhile all three leaves are alive, you will take 20% less damage\nAfter loosing leaves you must wait for them to re-emerge";
            player.GetModPlayer<TrelamiumModPlayer>().alluviumArmor = true;
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
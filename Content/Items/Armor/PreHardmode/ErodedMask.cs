 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Head)]

    public class ErodedMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Eroded Mask");
            //Tooltip.SetDefault("Increases melee damage by 8%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<ErodedBreastplate>() && legs.type == ModContent.ItemType<ErodedGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Melee attacks inflict Rust Poisoning";
            player.AddBuff(ModContent.BuffType<RustPoisoning>(), 2);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
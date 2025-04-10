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

    public class LuminescentVisor : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Luminescent Visor");
            //Tooltip.SetDefault("Increases minion damage by 12%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 1;
            Item.defense = 4;
            Item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<LuminescentChestplate>() && legs.type == ModContent.ItemType<LuminescentLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.012f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Minions inflict various debuffs depending on the player's health\nWhen below 60% of health minions inflict Granite Overload\nWhen below 30% of health minion damage is increased by 5 and minions inflict Confused\nWhen below 10% of health minions inflict all of the previous debuffs at once";
            player.GetModPlayer<TrelamiumModPlayer>().graniteArmor = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
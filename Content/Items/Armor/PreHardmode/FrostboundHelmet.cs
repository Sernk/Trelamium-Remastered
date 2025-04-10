 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Head)]

    public class FrostboundHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Frostbound Helmet");
            //Tooltip.SetDefault("Increases melee critical strike chance by 5");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 1;
            Item.defense = 4;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<FrostboundChestplate>() && legs.type == ModContent.ItemType<FrostboundLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 5;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "8% increased movement speed and ice mobility";
            player.iceSkate = true;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemID.WoodHelmet);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
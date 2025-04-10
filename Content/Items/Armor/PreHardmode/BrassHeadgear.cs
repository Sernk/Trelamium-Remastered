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

    public class BrassHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Brass Headgear");
            //Tooltip.SetDefault("Increases throwing damage by 10%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 85, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<BrassPlate>() && legs.type == ModContent.ItemType<BrassCuisse>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.010f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing weapons cut enemies defense in 1/4\nThrowing weapons also penetrate";
            player.GetModPlayer<TrelamiumModPlayer>().marbleArmor = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassChunk>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
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
    [AutoloadEquip(EquipType.Head)]

    public class PrimordialHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primordial Helmet");
            //Tooltip.SetDefault("Increases ranged damage by 6%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 3;
            Item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<PrimordialChestplate>() && legs.type == ModContent.ItemType<PrimordialBoots>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.06f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% chance not to consume ammo";
            player.ammoCost80 = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 12);
            recipe.AddIngredient(ItemID.AntlionMandible, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
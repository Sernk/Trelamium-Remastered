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

    public class AmbersteelHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ambersteel Headgear");
            //Tooltip.SetDefault("Increases thrown damage by 10%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 6;
            Item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<AmbersteelBreastguard>() && legs.type == ModContent.ItemType<AmbersteelLeggings>();
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.12f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased throwing velocity by 15%";
            player.ThrownVelocity += 0.15f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmbersteelAlloy>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
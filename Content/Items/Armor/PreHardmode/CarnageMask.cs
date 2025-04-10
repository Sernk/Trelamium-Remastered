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

    public class CarnageMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Carnage Mask");
            // Tooltip.SetDefault("Increases throwing damage by 8%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 4;
            Item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<CarnagePlate>() && legs.type == ModContent.ItemType<CarnageGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing weapons will inflict Bleeding\nIncreased damage reduction by 5%";
            player.endurance += 0.5f;
            player.GetModPlayer<TrelamiumModPlayer>().carnageArmor = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DripplingStone>(), 16);
            recipe.AddIngredient(ModContent.ItemType<DecayedTooth>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
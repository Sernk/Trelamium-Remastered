using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Armor.Hardmode
{
    [AutoloadEquip(EquipType.Head)]

    public class HypersonicHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hypersonic Headgear");
            //Tooltip.SetDefault("Increases melee speed by 25%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 7;
            Item.defense = 18;
            Item.value = Terraria.Item.buyPrice(0, 2, 75, 0);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<HypersonicChestplate>() && legs.type == ModContent.ItemType<HypersonicBoots>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "The faster you are moving increases your stats greatly, the slower you move decreases your stats greatly.\nWhen below 30% of your maximum health, your movement speed is pushed to the limit.";
            float playerVel = player.velocity.Length() / 4;
            player.GetDamage(DamageClass.Melee) += 5f * playerVel / 50;
            player.GetDamage(DamageClass.Magic) += 5f * playerVel / 50;
            player.GetDamage(DamageClass.Ranged) += 5f * playerVel / 50;
            player.GetDamage(DamageClass.Throwing) += 5f * playerVel / 50;
            player.GetDamage(DamageClass.Summon) += 5f * playerVel / 50;

            if (player.statLife <= (player.statLifeMax2 * 0.30f))
            {
                player.moveSpeed += 5f;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoPrism>(), 16);
            recipe.AddTile(ModContent.TileType<SoundConversatorTile>());
            recipe.Register();
        }
    }
}
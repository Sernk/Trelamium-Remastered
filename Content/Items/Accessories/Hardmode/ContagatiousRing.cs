using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Accessories.Hardmode
{
    public class ContagatiousRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Contagatious Ring");
            //Tooltip.SetDefault("Increases damage by 10%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 5;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.GetDamage(DamageClass.Magic) += 0.1f;
            player.GetDamage(DamageClass.Throwing) += 0.1f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VirulentRemnant>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
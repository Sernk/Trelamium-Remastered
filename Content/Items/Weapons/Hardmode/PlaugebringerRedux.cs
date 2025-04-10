using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class PlaugebringerRedux : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Plaguebringer Redux");
            // Tooltip.SetDefault("");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 14;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 20f;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<PlaugebringerReduxProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 18);
            recipe.AddIngredient(ItemID.CursedFlame, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}

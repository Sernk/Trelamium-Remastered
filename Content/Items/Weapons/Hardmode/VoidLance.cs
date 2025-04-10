using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class VoidLance : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Necroplasmic VoidLance");
            // Tooltip.SetDefault("Fires a beam from the peak of the lance");
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.crit = 4;
            Item.rare = 7;
            Item.width = 54;
            Item.height = 56;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 5;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            Item.UseSound = SoundID.Item73;
            Item.shoot = ModContent.ProjectileType<VoidlanceProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
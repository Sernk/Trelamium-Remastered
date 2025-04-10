using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class BrassStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Brass Staff");
            //Tooltip.SetDefault("Casts a barrage of acient swords"
            //    + "\nAncient swords multiply on enemy hit");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.rare = 3;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 8;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<AncientBladeProjectile>();
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
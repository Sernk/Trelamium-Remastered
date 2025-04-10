using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class LuminescentStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Luminescent Staff");
            // Tooltip.SetDefault("Summons a surge elemental to fight for you");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.rare = 1;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.mana = 10;
            Item.shootSpeed = 15f;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 3, 75, 0);
            Item.UseSound = SoundID.Item77;
            Item.shoot = ModContent.ProjectileType<SurgeElementalMinionProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
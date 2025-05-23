﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ScouterStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scouter Staff");
            // Tooltip.SetDefault("Summons a meteorite scouter to fight for you");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.rare = 3;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.mana = 12;
            Item.shootSpeed = 12f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item77;
            Item.shoot = ModContent.ProjectileType<ScouterMinionProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
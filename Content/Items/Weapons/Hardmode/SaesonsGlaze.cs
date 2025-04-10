using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class SaesonsGlaze : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Saeson's Glaze");
            /* Tooltip.SetDefault("The truimphet glaze of Saeson..."
                + "\nFires a bolt of solar energy which defracts into magma chunks"
                + "\nHitting enemies with the blade inflicts Solar God's Terror"
                + "\nWhen enemies are under 30% of there maximum health they leak magma from their insides"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.crit = 14;
            Item.rare = 7;
            Item.width = 54;
            Item.height = 56;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            Item.UseSound = SoundID.Item1;
            //item.shoot = ModContent.ProjectileType<SolarBoltProjectile>();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<SolarGodsTerror>(), 60);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CombustionBlade>());
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
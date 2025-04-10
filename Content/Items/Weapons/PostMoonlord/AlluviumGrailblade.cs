//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;

//namespace TrelamiumRemastered.Content.Items.Weapons.PostMoonlord
//{
//    public class AlluviumGrailblade : ModItem
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Alluvium Grailblade");
//            Tooltip.SetDefault("'The Guardian of the Forest...'"
//                + "\nFires a massive barrage of everbloom leaves that split into more leaves"
//                + "\nWhen everbloom leaves die, they release spiritual energy, which homes on enemies and heals health"
//                + "\nMelee attacks inflict Forest Guardian");
//        }

//        public override void SetDefaults()
//        {
//            item.damage = 78;
//            item.crit = 10;
//            item.rare = -12;
//            item.expert = true;
//            item.width = 70;
//            item.height = 70;
//            item.useAnimation = 20;
//            item.useTime = 20;
//            item.useStyle = 1;
//            item.knockBack = 4.5f;
//            item.shootSpeed = 20f;
//            item.melee = true;
//            item.autoReuse = true;
//            item.value = Terraria.Item.buyPrice(1, 75, 0, 0);
//            item.UseSound = SoundID.Item1;
//            //item.shoot = ModContent.ProjectileType<EverbloomLeafProjectile>();
//        }
//        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
//        {
//            target.AddBuff(mod.BuffType("ForestGuardian"), 200);
//        }
//        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
//        {
//            int numberProjectiles = 5;
//            for (int i = 0; i < numberProjectiles; i++)
//            {
//                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
//                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
//            }
//            return false;
//        }
//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(ModContent.ItemType<AlluviumBlade>());
//            recipe.AddIngredient(ModContent.ItemType<QuantumComponent>(), 5);
//            recipe.AddTile(TileID.LunarCraftingStation);
//            recipe.Register();
//        }
//        public override void ModifyTooltips(List<TooltipLine> tooltips)
//        {
//            foreach (TooltipLine rarity in tooltips)
//            {
//                if (rarity.mod == "Terraria" && rarity.Name == "ItemName")
//                {
//                    rarity.overrideColor = new Color(81, 255, 240);
//                }
//            }
//        }
//    }
//}
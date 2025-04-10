using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HolyGrail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Earth's Grail");
            // Tooltip.SetDefault("Hitting enemies creates sandnados at the point of your cursor");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 20;
            Item.rare = 8;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int projectileIndex = Projectile.NewProjectile(player.GetSource_FromThis(), Main.MouseWorld.X + 1, Main.MouseWorld.Y, -.001f, 0, ProjectileID.SandnadoFriendly, Item.damage, Item.knockBack, Item.playerIndexTheItemIsReservedFor);
            Main.projectile[projectileIndex].timeLeft = 120;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 18);
            recipe.AddIngredient(ItemID.Pwnhammer);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
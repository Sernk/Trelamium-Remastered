using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Infestation : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infestation");
            // Tooltip.SetDefault("Striking enemies creates a swarm of arachnids");
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 52;
            Item.height = 52;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 5.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            Item.UseSound = SoundID.Item1;
        }
        //public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        //{
        //    int type = ModContent.ProjectileType<SpiderProjectile>();
        //    Projectile.NewProjectile(target.position.X, target.position.Y, target.width, target.height, type, damage, knockBack, player.whoAmI);
        //}
    }
}
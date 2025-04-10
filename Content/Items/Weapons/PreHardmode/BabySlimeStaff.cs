using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class BabySlimeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Baby Slime Staff");
            //Tooltip.SetDefault("Summons a Baby Slime to fight for you"
            //    + "\nBaby slimes take up half a minion slot");
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
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
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item77;
            Item.shoot = ModContent.ProjectileType<BabySlimeMinionProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ModContent.ItemType<MurkyGel>(), 8);
            recipe.Register();
        }
    }
}

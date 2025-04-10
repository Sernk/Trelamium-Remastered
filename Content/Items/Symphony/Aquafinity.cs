using TrelamiumRemastered.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class Aquafinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aquafinity");
            //Tooltip.SetDefault("");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 10;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.crit = 10;
            Item.rare = 6;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 22f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<AquafinityProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 12);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}

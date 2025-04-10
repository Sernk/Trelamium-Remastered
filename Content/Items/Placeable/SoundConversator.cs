using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Placeable
{
    public class SoundConversator : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sound Conversator");
            //Tooltip.SetDefault("Used to craft sound-related gear");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.rare = 2;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<SoundConversatorTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SoundPrism>(), 12);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
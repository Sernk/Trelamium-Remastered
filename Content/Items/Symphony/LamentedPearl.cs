using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs.Symphony;

namespace TrelamiumRemastered.Content.Items.Symphony
{
	public class LamentedPearl : ModItem
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("Lamented Pearl");
            // Tooltip.SetDefault("Summons the Sirens of the Tide");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.rare = -12;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
			return player.ZoneBeach && !NPC.AnyNPCs(ModContent.NPCType<Rin>()) && !NPC.AnyNPCs(ModContent.NPCType<Arroya>()) && !NPC.AnyNPCs(ModContent.NPCType<Darya>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Rin>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Arroya>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Darya>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			if (Main.dayTime)
			{
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ModContent.ItemType<SoundPrism>(), 5);
				recipe.AddIngredient(ItemID.Coral, 5);
				recipe.AddIngredient(ItemID.Seashell, 2);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}
	}
}
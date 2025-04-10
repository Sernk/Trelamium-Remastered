using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Items.Memes
{
	public class McDonaldsKidsMeal : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("McDonald's Kid's Meal");
			//Tooltip.SetDefault("Summons a large Humback Whale");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish);
			Item.shoot = ModContent.ProjectileType<WhalePetProjectile>();
			Item.buffType = ModContent.BuffType<WhalePet>();
            Item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}
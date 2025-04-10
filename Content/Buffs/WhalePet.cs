using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Buffs
{
	public class WhalePet : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Humback Whale");
			//Description.SetDefault("\"WOO OWOWOW OWWO\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<TrelamiumModPlayer>().whalePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<WhalePetProjectile>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetSource_FromThis(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<WhalePetProjectile>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Projectiles.Minions
{
	public class WhalePetProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Humpback Whale");
			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
			if (player.dead)
			{
				modPlayer.whalePet = false;
			}
			if (modPlayer.whalePet)
			{
				Projectile.timeLeft = 2;
			}
		}
	}
}
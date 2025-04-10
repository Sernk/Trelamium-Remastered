using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Mounts.PreHardmode.Buffs;

namespace TrelamiumRemastered.Content.Mounts.PreHardmode
{
	public class FleshCart : ModMount
	{
		public override void SetStaticDefaults()
		{
            MountData.spawnDust = 5;
            MountData.buff = ModContent.BuffType<FleshCartBuff>();
            MountData.heightBoost = 20;
            MountData.fallDamage = 0.5f;
            MountData.runSpeed = 10f;
            MountData.dashSpeed = 5f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 5;
            MountData.acceleration = 0.18f;
            MountData.jumpSpeed = 6.5f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 3;
            MountData.constantJump = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 16;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 5;
            MountData.yOffset = 16;
            MountData.bodyFrame = 3;
            MountData.playerHeadOffset = 22;
            MountData.standingFrameCount = 3;
            MountData.standingFrameDelay = 12;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 3;
            MountData.runningFrameDelay = 12;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 0;
            MountData.flyingFrameDelay = 0;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 0;
            MountData.idleFrameDelay = 24;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;
            MountData.swimFrameCount = MountData.inAirFrameCount;
            MountData.swimFrameDelay = MountData.inAirFrameDelay;
            MountData.swimFrameStart = MountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                MountData.textureWidth = MountData.backTexture.Value.Width;
                MountData.textureHeight = MountData.backTexture.Value.Height;
            }
        }

        public override void UpdateEffects(Player player)
		{
			if (Math.Abs(player.velocity.X) > 4f)
			{
				Rectangle rect = player.getRect();
				Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 5);
			}
		}
	}
}
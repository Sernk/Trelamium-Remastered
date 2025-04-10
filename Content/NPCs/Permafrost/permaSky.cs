using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Permafrost
{
	public class permaSky : CustomSky
	{
		private bool isActive = false;
		private float intensity = 0f;
		private int permaIndex;

		public override void Update(GameTime gameTime)
		{
			if (isActive && intensity < 2f)
			{
				intensity += 0.01f;
			}
			else if (!isActive && intensity > 0f)
			{
				intensity -= 0.01f;
			}
		}

		private bool UpdatepermaIndex()
		{
			int permaType = ModLoader.GetMod("TrelamiumMod").Find<ModNPC>("PermafrostRun").Type;
			if (permaIndex >= 0 && Main.npc[permaIndex].active && Main.npc[permaIndex].type == permaType)
			{
				return true;
			}
			permaIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == permaType)
				{
					permaIndex = i;
					break;
				}
			}
			return permaIndex >= 0;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0 && minDepth < 0)
			{
				spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(1, 1, 1) * intensity);
			}
		}

		public override float GetCloudAlpha()
		{
			return 0f;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			isActive = true;
		}

		public override void Deactivate(params object[] args)
		{
			isActive = false;
		}

		public override void Reset()
		{
			isActive = false;
		}

		public override bool IsActive()
		{
			return isActive || intensity > 0f;
		}
	}
}
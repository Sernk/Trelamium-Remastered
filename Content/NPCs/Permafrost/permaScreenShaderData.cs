using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Permafrost
{
	public class permaScreenShaderData : ScreenShaderData
	{
		private int permaIndex;

		public permaScreenShaderData(string passName)
			: base(passName)
		{
		}

		private void UpdatepermaIndex()
		{
			int permaType = ModLoader.GetMod("TrelamiumMod").Find<ModNPC>("PermafrostRun").Type;
			if (permaIndex >= 0 && Main.npc[permaIndex].active && Main.npc[permaIndex].type == permaType)
			{
				return;
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
		}

		public override void Apply()
		{
			UpdatepermaIndex();
			if (permaIndex != -1)
			{
				UseTargetPosition(Main.npc[permaIndex].Center);
			}
			base.Apply();
		}
	}
}
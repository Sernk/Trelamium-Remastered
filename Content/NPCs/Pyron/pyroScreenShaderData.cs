using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Pyron
{
	public class pyroScreenShaderData : ScreenShaderData
	{
		private int pyroIndex;

		public pyroScreenShaderData(string passName)
			: base(passName)
		{
		}

		private void UpdatepyroIndex()
		{
			int pyroType = ModLoader.GetMod("TrelamiumMod").Find<ModNPC>("PyronHead").Type;
			if (pyroIndex >= 0 && Main.npc[pyroIndex].active && Main.npc[pyroIndex].type == pyroType)
			{
				return;
			}
			pyroIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == pyroType)
				{
					pyroIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdatepyroIndex();
			if (pyroIndex != -1)
			{
				UseTargetPosition(Main.npc[pyroIndex].Center);
			}
			base.Apply();
		}
	}
}
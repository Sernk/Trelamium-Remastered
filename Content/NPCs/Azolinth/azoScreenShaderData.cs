using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.NPCs.Azolinth
{
	public class azoScreenShaderData : ScreenShaderData
	{
		private int azoIndex;

		public azoScreenShaderData(string passName)
			: base(passName)
		{
		}

		private void UpdateazoIndex()
		{
			int azoType = ModLoader.GetMod("TrelamiumMod").Find<ModNPC>("AzolinthHead").Type;
			if (azoIndex >= 0 && Main.npc[azoIndex].active && Main.npc[azoIndex].type == azoType)
			{
				return;
			}
			azoIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == azoType)
				{
					azoIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdateazoIndex();
			if (azoIndex != -1)
			{
				UseTargetPosition(Main.npc[azoIndex].Center);
			}
			base.Apply();
		}
	}
}
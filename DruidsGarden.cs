using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace TrelamiumRemastered
{
    public class DruidsGarden : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            return BiomeTileCounterSystem.ZoneDruidsGarden > 250;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DruidsGarden");
    }
}

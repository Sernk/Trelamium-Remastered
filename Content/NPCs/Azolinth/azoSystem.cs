//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.GameContent;
//using Terraria.Graphics.Shaders;
//using Terraria.ModLoader;

//namespace TrelamiumRemastered.Content.NPCs.Azolinth отключено на время
//{
//    public class azoSystem : ModSystem
//    {
//        public override void PostDrawInterface(SpriteBatch spriteBatch)
//        {
//            foreach (Player player in Main.player)
//            {
//                if (player.active && !player.dead && player.GetModPlayer<TrelamiumModPlayer>().azolinthActive) 
//                {
//                    Texture2D overlay = TextureAssets.MagicPixel.Value;
//                    Color blueOverlay = new Color(100, 100, 255, 50); 
//                    spriteBatch.Draw( overlay,new Rectangle(0, 0, Main.screenWidth, Main.screenHeight),blueOverlay );
//                    break; 
//                }
//            }
//        }
//    }
//}
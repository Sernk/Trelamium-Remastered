using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Tiles;

namespace TrelamiumRemastered
{
    public class TrelamiumModWorld : ModSystem
    {
        private const int saveVersion = 0;
        public static int druidsGardenTiles = 0;

        public static bool downedAzolinth = false;
        public static bool downedCrystallineSerpent = false;
        public static bool downedCumulor = false;
        public static bool downedParadoxHive = false;
        public static bool downedPermafrost = false;
        public static bool downedPholiotaGoliath = false;
        public static bool downedPyron = false;
        public static bool downedSymphony = false;

        public int Num;

        public override void OnWorldLoad()
        {
            downedAzolinth = false;
            downedCrystallineSerpent = false;
            downedCumulor = false;
            downedParadoxHive = false;
            downedPermafrost = false;
            downedPholiotaGoliath = false;
            downedPyron = false;
            downedSymphony = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedAzolinth) downed.Add("AzolinthHead");
            if (downedCrystallineSerpent) downed.Add("CrystallineSerpentHead");
            if (downedCumulor) downed.Add("RulerOfSkies");
            if (downedParadoxHive) downed.Add("ParadoxHive");
            if (downedPermafrost) downed.Add("PermafrostRun");
            if (downedPholiotaGoliath) downed.Add("PholiotaGoliath");
            if (downedPyron) downed.Add("PyronHead");
            if (downedSymphony) downed.Add("Rin");

            //return new TagCompound {
            //    {"downed", downed}
            //};
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedAzolinth = downed.Contains("AzolinthHead");
            downedCrystallineSerpent = downed.Contains("CrystallineSerpentHead");
            downedCumulor = downed.Contains("RulerOfSkies");
            downedParadoxHive = downed.Contains("ParadoxHive");
            downedPermafrost = downed.Contains("PermafrostRun");
            downedPholiotaGoliath = downed.Contains("PholiotaGoliath");
            downedPyron = downed.Contains("PyronHead");
            downedSymphony = downed.Contains("Rin");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedAzolinth;
            flags[1] = downedCrystallineSerpent;
            flags[2] = downedCumulor;
            flags[3] = downedParadoxHive;
            flags[4] = downedPermafrost;
            flags[5] = downedPholiotaGoliath;
            flags[6] = downedPyron;
            flags[7] = downedSymphony;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedAzolinth = flags[0];
            downedCrystallineSerpent = flags[1];
            downedCumulor = flags[2];
            downedParadoxHive = flags[3];
            downedPermafrost = flags[4];
            downedPholiotaGoliath = flags[5];
            downedPyron = flags[6];
            downedSymphony = flags[7];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }

            tasks.Insert(ShiniesIndex + 1, new PassLegacy("GenShroom", (progress, config) =>
            {
                progress.Message = "Trelamium Mod Ores";

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .5f));
                    if (Main.tile[i2, j2].TileType == TileID.Sand || Main.tile[i2, j2].TileType == TileID.Sandstone)
                        WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(4, 11), WorldGen.genRand.Next(4, 11), (ushort)Mod.Find<ModTile>("PrimordialStoneTile").Type);
                }

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .5f));
                    if (Main.tile[i2, j2].TileType == TileID.Stone)
                        WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), (ushort)Mod.Find<ModTile>("AgateTile").Type);
                }
            }));

            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            if (LivingTreesIndex != -1)
            {
                tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", (progress, config) =>
                {
                    progress.Message = "Overgrowing the hidden Forest...";
                    GrowGarden(); 
                }));
            }
        }
        private void GrowGarden()
        {
            for (int i = 0; i < (int)Main.maxTilesX / 900; i++)
            {
                int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
                int Yvalue = WorldGen.genRand.Next((int)GenVars.rockLayer - 200, Main.maxTilesY - 700);
                int XvalueHigh = Xvalue + 800;
                int YvalueHigh = Yvalue + 800;
                int XvalueMid = Xvalue + 400;
                int YvalueMid = Yvalue + 400;

                WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(300, 300), 1, Mod.Find<ModTile>("EnchantedSoilTile").Type, false, 0f, 0f, true, true);
                WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0, 0, WorldGen.genRand.Next(11, 22), WorldGen.genRand.Next(11, 22), false);
                Main.tile[Xvalue, Yvalue].WallType = WallID.Grass;
                for (int Ore = 0; Ore < 650; Ore++)
                {
                    int oreX = XvalueMid + Main.rand.Next(-300, 300);
                    int oreY = YvalueMid + Main.rand.Next(-300, 300);
                    if (Main.tile[oreX, oreY].TileType == Mod.Find<ModTile>("EnchantedSoilTile").Type)
                    {
                        WorldGen.TileRunner(oreX, oreY, (double)WorldGen.genRand.Next(6, 12), WorldGen.genRand.Next(8, 14), Mod.Find<ModTile>("AlluviumOreTile").Type, false, 0f, 0f, false, true);
                    }
                }
                for (int X1 = -2; X1 < 8; X1++)
                {
                    WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 1, Mod.Find<ModTile>("EnchantedSoilTile").Type);
                }
                for (int X1 = -1; X1 < 7; X1++)
                {
                    WorldGen.PlaceTile(XvalueMid + X1, YvalueMid + 2, Mod.Find<ModTile>("EnchantedSoilTile").Type);
                }
                WorldGen.PlaceObject(XvalueMid - 1, YvalueMid - 1, Mod.Find<ModTile>("DruidChestTile").Type, false, 5); //Campfires
                WorldGen.PlaceObject(XvalueMid + 6, YvalueMid - 1, Mod.Find<ModTile>("DruidChestTile").Type, false, 5); //Campfires
            }
        }
        public override void PostWorldGen()
        {
            int[] itemsToPlaceInWaterChests = new int[] { Mod.Find<ModItem>("Verdant").Type, Mod.Find<ModItem>("AlluviumBar").Type, 10 };
            int itemsToPlaceInWaterChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex]; 
                if (chest != null && Main.tile[chest.x, chest.y].TileType == Mod.Find<ModTile>("DruidChestTile").Type)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWaterChests[itemsToPlaceInWaterChestsChoice]);
                            itemsToPlaceInWaterChestsChoice = (itemsToPlaceInWaterChestsChoice + 1) % itemsToPlaceInWaterChests.Length;
                            break;
                        }
                    }
                }
            }
        }
        public override void ResetNearbyTileEffects()
        {
            TrelamiumModPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TrelamiumModPlayer>();
            druidsGardenTiles = 0;
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            druidsGardenTiles = tileCounts[Mod.Find<ModTile>("EnchantedSoilTile").Type];
        }

    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.GameContent.ItemDropRules;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.Items.Azolinth;
using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;
using TrelamiumRemastered.Content.Mounts.PreHardmode;
using TrelamiumRemastered.Content.Items.Weapons.Hardmode;
using TrelamiumRemastered.Content.Items.Memes;
using Terraria.GameContent.Biomes;

namespace TrelamiumRemastered
{
    public class TrelamiumModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public static bool insanityStart = false;
        public bool antlionSwarmer = false;
        public bool babySlime = false;
        public bool blighted = false;
        public bool desolation = false;
        public bool fractured = false;
        public bool galaticTorment = false;
        public bool graniteOverload = false;
        public bool hellfire = false;
        public bool marbleShatter = false;
        public bool moonburn = false;
        public bool necroplasm = false;
        public bool ospreyFalcon = false;
        public bool permafrostDebuff = false;
        public bool phantoDebuff = false;
        public bool radiantEuphoria = false;
        public bool rottingDebuff = false;
        public bool rustPoisoning = false;
        public bool scouterMinion = false;
        public bool shadowflameApparition = false;
        public bool sirensLament = false;
        public bool solarGodBuff = false;
        public bool ventureBoots = false;
        public bool volcanAcid = false;
        public bool whalePet = false;

        public override void ResetEffects(NPC npc)
        {
            antlionSwarmer = false;
            babySlime = false;
            blighted = false;
            desolation = false;
            fractured = false;
            galaticTorment = false;
            graniteOverload = false;
            hellfire = false;
            marbleShatter = false;
            moonburn = false;
            necroplasm = false;
            ospreyFalcon = false;
            permafrostDebuff = false;
            phantoDebuff = false;
            radiantEuphoria = false;
            rottingDebuff = false;
            rustPoisoning = false;
            scouterMinion = false;
            shadowflameApparition = false;
            sirensLament = false;
            solarGodBuff = false;
            ventureBoots = false;
            volcanAcid = false;
            whalePet = false;

        }
        public override void SetDefaults(NPC npc)
        {
            Player player = Main.LocalPlayer;
            if (insanityStart)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.40f);
                npc.damage = (int)(npc.damage * 1.40f);
                if (npc.aiStyle == 7)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1f);
                    npc.damage = (int)(npc.damage * 1f);
                }
            }
            else
            {
                npc.lifeMax = (int)(npc.lifeMax * 1f);
                npc.damage = (int)(npc.damage * 1f);
            }
        }
        #region Buff Stuff Boi
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            Player player = Main.player[Main.myPlayer];
            if (desolation)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 30;
                if (damage < 10)
                {
                    damage = 10;
                }
            }
            if (volcanAcid)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 50;
                if (damage < 5)
                {
                    damage = 5;
                }
            }
            if (permafrostDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 15;
                if (damage < 3)
                {
                    damage = 3;
                }
            }
            if (fractured)
            {
                npc.defense /= 2;
            }
            if (marbleShatter)
            {
                npc.defense /= 4;
            }
            if (radiantEuphoria)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 95;
                if (damage < 35)
                {
                    damage = 35;
                }
            }
            if (rustPoisoning)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 15;
                if (damage < 1)
                {
                    damage = 1;
                }
            }
            if (hellfire)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 95;
                if (damage < 4)
                {
                    damage = 4;
                }
            }
            if (phantoDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 180;
                if (damage < 6)
                {
                    damage = 6;
                }
            }
            if (graniteOverload)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 30;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
            if (rottingDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 20;
                if (damage < 6)
                {
                    damage = 6;
                }
            }
            if (moonburn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 20;
                if (damage < 10)
                {
                    damage = 10;
                }
            }
            if (necroplasm)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 60;
                if (damage < 4)
                {
                    damage = 4;
                }
            }
            if (galaticTorment)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 25;
                if (damage < 10)
                {
                    damage = 10;
                }
            }
            if (sirensLament)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 25;
                if (damage < 5)
                {
                    damage = 5;
                }
            }
            if (solarGodBuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 25;
                if (damage < 16)
                {
                    damage = 16;
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (desolation)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 235, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0f, 0.25f);
            }

            if (permafrostDebuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 67, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 80, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
                Lighting.AddLight(npc.position, 0f, 0f, 0.25f);
            }
            if (phantoDebuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 160, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (necroplasm)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 235, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 27, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 0.65f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (graniteOverload)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 206, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (rustPoisoning)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 7, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 0.65f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (rottingDebuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 5, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 0.65f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (radiantEuphoria)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 264, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0.8f, 0.5f, 0.5f);
            }
            if (solarGodBuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 80, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
                Lighting.AddLight(npc.position, 0.10f, 0.10f, 0.04f);
            }
            if (hellfire)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 75, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 70, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
                Lighting.AddLight(npc.position, 0.10f, 0.10f, 0.04f);
            }
            if (volcanAcid)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 74, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0.10f, 0.10f, 0.04f);
            }
            if (sirensLament)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 172, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.15f;
                    }
                }
                Lighting.AddLight(npc.position, 0.10f, 0.10f, 0.04f);
            }
            if (moonburn)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 229, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
            if (galaticTorment)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 21, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.25f;
                    }
                }
                Lighting.AddLight(npc.position, 0f, 0.10f, 0.25f);
            }
        }

        #endregion
        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.MoonLordCore && !NPC.downedMoonlord)
            {
                Main.NewText("The gate between rifts have been opened!", new Color(43, 100, 255));
                Main.NewText("Blighted matter scatters on the surface...", new Color(50, 50, 50));
            }
            if (npc.type == NPCID.BrainofCthulhu && !NPC.downedBoss2)
            {
                Main.NewText("Thunder crashes from the aethers...", new Color(85, 145, 255));
            }
            if (npc.type == NPCID.EaterofWorldsHead && Main.rand.Next(20) == (0) && !NPC.downedBoss2)
            {
                Main.NewText("Thunder crashes from the aethers...", new Color(85, 145, 255));
            }
            if (npc.type == NPCID.SkeletronHead && !NPC.downedBoss3)
            {
                Main.NewText("The forests echo with despair...", new Color(125, 212, 0));
                Main.NewText("The tides grow rampant...", new Color(125, 75, 255));
            }
            if (npc.type == NPCID.EyeofCthulhu && !NPC.downedBoss1)
            {
                Main.NewText("The caverns run rampant with energy...", new Color(240, 190, 30));
            }

            if (NPC.downedBoss1)
            {
                if (npc.type == NPCID.GraniteGolem || npc.type == NPCID.GraniteFlyer)
                {
                    if (Main.rand.NextFloat() < 0.20f)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<LuminescentGeode>(), amount);
                    }
                }
            }
            if (NPC.downedBoss2)
            {
                if (npc.type == NPCID.Harpy)
                {
                    if (Main.rand.NextFloat() < 0.20f)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<AerialEssence>(), amount);
                    }
                }
            }
            if (Main.hardMode)
            {
                if (npc.type == NPCID.WalkingAntlion || npc.type == NPCID.FlyingAntlion || npc.type == NPCID.DesertBeast)
                {
                    if (Main.rand.NextFloat() < 0.20f)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<PrimevalClaw>(), amount);
                    }
                }
                if (npc.type == NPCID.FloatyGross || npc.type == NPCID.BloodCrawler || npc.type == NPCID.Herpling || npc.type == NPCID.IchorSticker)
                {
                    if (Main.rand.NextFloat() < 0.20f)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<VirulentRemnant>(), amount);
                    }
                }
                if (npc.type == NPCID.Corruptor || npc.type == NPCID.EaterofSouls || npc.type == NPCID.SeekerHead || npc.type == NPCID.DevourerHead)
                {
                    if (Main.rand.NextFloat() < 0.20f)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<NecromanticRemnant>(), amount);
                    }
                }
            }
            if (Main.bloodMoon)
            {
                if (Main.rand.NextFloat() < 0.30f)
                {
                    int amount = Main.rand.Next(1, 2);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<DripplingStone>(), amount);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<DecayedTooth>(), amount);
                }
            }

            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerNebula)
            {
                if (Main.rand.NextFloat() < 0.10f)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ItemID.FragmentNebula, amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerSolar)
            {
                if (Main.rand.NextFloat() < 0.10f)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ItemID.FragmentSolar, amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerVortex)
            {
                if (Main.rand.NextFloat() < 0.10f)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ItemID.FragmentVortex, amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerStardust)
            {
                if (Main.rand.NextFloat() < 0.10f)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ItemID.FragmentStardust, amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach)
            {
                if (Main.rand.NextFloat() < 0.20f)
                {
                    int amount = Main.rand.Next(1, 2);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<SeaEssence>(), amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
            {
                if (Main.rand.NextFloat() < 0.20f)
                {
                    int amount = Main.rand.Next(1, 2);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<SoundPrism>(), amount);
                }
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].InModBiome<DruidsGarden>())
            {
                if (Main.rand.NextFloat() < 0.20f)
                {
                    int amount = Main.rand.Next(1, 2);
                    Item.NewItem(npc.GetSource_Loot(), npc.position, ModContent.ItemType<NatureEssence>(), amount);
                }
            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ItemID.FragmentNebula, 7000));
            //npcLoot.Add(ItemDropRule.Common(ItemID.FragmentSolar, 7000));
            //npcLoot.Add(ItemDropRule.Common(ItemID.FragmentVortex, 7000));
            //npcLoot.Add(ItemDropRule.Common(ItemID.FragmentStardust, 7000));
            
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoundPrism>(), 999999, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NatureEssence>(), 999999, 1, 3));
            if (npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler || npc.type == NPCID.TheGroom || npc.type == NPCID.TheBride || npc.type == NPCID.Clown || npc.type == NPCID.BloodEelHead || npc.type == NPCID.BloodEelBody || npc.type == NPCID.BloodEelTail || npc.type == NPCID.BloodSquid)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DripplingStone>(), 3, 1, 2));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DecayedTooth>(), 3, 1, 2));
            }
            if (npc.type == NPCID.WalkingAntlion || npc.type == NPCID.FlyingAntlion || npc.type == NPCID.DesertBeast)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimevalClaw>(), 999999, 1, 3));
            }
            if (npc.type == NPCID.Corruptor || npc.type == NPCID.EaterofSouls || npc.type == NPCID.SeekerHead || npc.type == NPCID.DevourerHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NecromanticRemnant>(), 999999, 1, 3));
            }
            if (npc.type == NPCID.FloatyGross || npc.type == NPCID.BloodCrawler || npc.type == NPCID.Herpling || npc.type == NPCID.IchorSticker)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VirulentRemnant>(), 999999, 1, 3));
            }
            if (npc.type == NPCID.Harpy)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AerialEssence>(), 999999, 1, 3));
            }
            if (npc.type == 39)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SerpentsEnsnare>(), 18));
            }
            if (npc.type == NPCID.GoblinSummoner)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ApparitionStaff>(), 5));
            }
            if (npc.type == 4)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SerpentsEnsnare>(), 18));
            }
            if (npc.type == NPCID.GraniteGolem || npc.type == NPCID.GraniteFlyer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuminescentGeode>(), 999999, 1, 3)); 
            }
            if (npc.type == NPCID.Shark || npc.type == NPCID.PinkJellyfish || npc.type == NPCID.BlueJellyfish || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.SeaSnail || npc.type == NPCID.Squid || npc.type == NPCID.Crab || npc.type == NPCID.SandShark)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeaEssence>(), 999999, 1, 2)); 
            }
            if (npc.type == NPCID.MartianSaucerCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnknownTechnology>(), 1, 1, 2));
            }
            if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimevalPetal>(), 1, 7, 18));
            }
            if (npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<GalaticCore>(), 1, 18, 26));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GalaticCore>(), 1, 14, 20));
            }
            if (npc.type == 3 || npc.type == 52 || npc.type == 53 || npc.type == 132 || npc.type == 186
                || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200
                || npc.type == 430 || npc.type == 431 || npc.type == 432 || npc.type == 433
                || npc.type == 434 || npc.type == 435 || npc.type == 436)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Zombow>(), 28));
            }
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeKey>(), 3));
            }
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshKey>(), 3));
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeofCthulhuKey>(), 3));
            }
        }
        public override void ModifyShop(NPCShop shop)
        {
            var Plantboss = new Condition("Plantboss", () => NPC.downedPlantBoss);
            var Boss2 = new Condition("Boss2", () => NPC.downedBoss2);
            var Boss1 = new Condition("Boss1", () => NPC.downedBoss1);
            if (shop.NpcType == NPCID.Dryad)
            {
                shop.Add(ItemID.LeafBlower, Plantboss);
                shop.Add(ItemID.Seedler, Plantboss);
                shop.Add(ItemID.Vertebrae, Boss2);
                shop.Add(ItemID.RottenChunk, Boss2);
                shop.Add(ItemID.LivingLoom);
                shop.Add(ItemID.LivingWoodWand);
                shop.Add(ItemID.LeafWand);
                shop.Add(ItemID.GlowingMushroom);
                shop.Add(ItemID.ViciousMushroom);
                shop.Add(ItemID.VileMushroom);
            }
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add(ItemID.MoneyTrough, Boss1);
                shop.Add(ModContent.ItemType<McDonaldsKidsMeal>());
            }
            if (shop.NpcType == NPCID.Truffle)
            {
                shop.Add(ItemID.GlowingMushroom);
            }
        }
    }
}
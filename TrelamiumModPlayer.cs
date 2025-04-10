using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace TrelamiumRemastered
{
    public class TrelamiumModPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public static bool hasProjectile;
        public bool algidityBelt = false;
        public bool alluviumArmor = false;
        public bool antlionSwarmer = false;
        public bool babySlime = false;
        public bool blighted = false;
        public bool carnageArmor = false;
        public bool desolation = false;
        public bool fractured = false;
        public bool galaticTorment = false;
        public bool graniteArmor = false;
        public bool graniteOverload = false;
        public bool hellfire = false;
        public int IceDash = 0;
        public bool marbleArmor = false;
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
        public bool surgeElemental = false;
        public bool ventureBoots = false;
        public bool volcanAcid = false;
        public bool whalePet = false;
        public bool ZoneDruidsGarden = false;

        public bool blazingStone = false;
        public bool aquamarineBarrier = false;
        public bool sirenLore = false;
        public bool fungiRoot = false;

        public override void ResetEffects()
        {
            antlionSwarmer = false;
            alluviumArmor = false;
            babySlime = false;
            blighted = false;
            carnageArmor = false;
            desolation = false;
            fractured = false;
            galaticTorment = false;
            graniteArmor = false;
            graniteOverload = false;
            hellfire = false;
            marbleArmor = false;
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
            surgeElemental = false;
            ventureBoots = false;
            volcanAcid = false;
            whalePet = false;

            blazingStone = false;
            aquamarineBarrier = false;
            sirenLore = false;
            fungiRoot = false;

        }
        public override void UpdateDead()
        {
            antlionSwarmer = false;
            alluviumArmor = false;
            babySlime = false;
            blighted = false;
            carnageArmor = false;
            desolation = false;
            fractured = false;
            galaticTorment = false;
            graniteArmor = false;
            graniteOverload = false;
            hellfire = false;
            marbleArmor = false;
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
            surgeElemental = false;
            ventureBoots = false;
            volcanAcid = false;
            whalePet = false;

            blazingStone = false;
            aquamarineBarrier = false;
            sirenLore = false;
            fungiRoot = false;

        }

        //public override void UpdateBiomes() НЕ ЗАБЫТЬ ЭТО ДОЛЖНО БЫТЬ В ДРУГОМ МЕСТЕ
        //{
        //    ZoneDruidsGarden = TrelamiumModWorld.druidsGardenTiles > 250;
        //}

        //public override void UpdateBiomeVisuals() Я не до конца понимаю что это оставлю тем кто поимеет это 
        //{
        //    bool usePerma = NPC.AnyNPCs(Mod.Find<ModNPC>("PermafrostRun").Type);
        //    Player.ManageSpecialBiomeVisuals("TrelamiumMod:PermafrostRun", usePerma);
        //    //---------------------------------------------------------------------//
        //    bool usePyro = NPC.AnyNPCs(Mod.Find<ModNPC>("PyronHead").Type);
        //    Player.ManageSpecialBiomeVisuals("TrelamiumMod:PyronHead", usePyro);
        //    //---------------------------------------------------------------------//
        //    bool useAzo = NPC.AnyNPCs(Mod.Find<ModNPC>("AzolinthHead").Type);
        //    Player.ManageSpecialBiomeVisuals("TrelamiumMod:AzolinthHead", useAzo);
        //}

        #region Buff Stuff
        public override void UpdateBadLifeRegen()
        {
            if (desolation)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 30;
            }
            if (volcanAcid)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 35;
            }
            if (fractured)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
            }
            if (galaticTorment)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 25;
            }
            if (graniteOverload)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 30;
            }

            if (hellfire)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 35;
            }
            if (marbleShatter)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
            }
            if (moonburn)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 15;
            }

            if (necroplasm)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 15;
            }

            if (permafrostDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 15;
            }

            if (phantoDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 25;
            }

            if (radiantEuphoria)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 35;
            }

            if (rottingDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 5;
            }

            if (rustPoisoning)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 10;
            }

            if (solarGodBuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 80;
            }
        }
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            return;
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (desolation)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 235, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 0.5f;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.5f;
                g *= 0f;
                b *= 0f;
                fullBright = true;
            }

            if (phantoDebuff)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 160, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.08f;
                b *= 0.10f;
                fullBright = true;
            }
            if (permafrostDebuff)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 67, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 50, default(Color), 1.2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 0.75f;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.01f;
                g *= 0.01f;
                b *= 0.15f;
                fullBright = true;
            }
            if (rottingDebuff)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 5, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0f;
                b *= 0f;
                fullBright = true;
            }
            if (graniteOverload)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 206, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0f;
                b *= 0.10f;
                fullBright = true;
            }
            if (hellfire)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 75, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.5f;
                b *= 0f;
                fullBright = true;
            }
            if (rustPoisoning)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 7, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].scale = 0.85f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0f;
                b *= 0f;
            }
            if (sirensLament)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 172, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0f;
                b *= 1f;
                fullBright = true;
            }
            if (radiantEuphoria)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 264, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0f;
                b *= 0f;
                fullBright = true;
            }
            if (moonburn)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 229, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.08f;
                b *= 0.10f;
                fullBright = true;
            }
            if (volcanAcid)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 74, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.08f;
                b *= 0.10f;
                fullBright = true;
            }
            if (solarGodBuff)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 127, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 50, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.8f;
                g *= 0.08f;
                b *= 0.03f;
                fullBright = true;
            }
            if (necroplasm)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 235, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 27, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 0.85f;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.25f;
                g *= 0f;
                b *= 0.25f;
                fullBright = true;
            }
            if (galaticTorment)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, 21, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    //Main.playerDrawDust.Add(dust);
                }
                r *= 0.25f;
                g *= 0f;
                b *= 0.25f;
                fullBright = true;
            }
        }
        #endregion

        #region Belt Stuff
        public void AlgidityDodge()
        {
            Player.immune = true;
            Player.immuneTime = 80;
            if (Player.longInvince)
            {
                Player.immuneTime += 40;
            }
            for (int i = 0; i < Player.hurtCooldowns.Length; i++)
            {
                Player.hurtCooldowns[i] = Player.immuneTime;
            }

            for (int j = 0; j < 100; j++)
            {
                int num = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, 229, 0f, 0f, 100, default(Color), 2f);
                Dust dust = Main.dust[num];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-20, 21);
                Dust dust2 = Main.dust[num];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-20, 21);
                Main.dust[num].velocity *= 0.4f;
                Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(Player.cWaist, Player);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                    Main.dust[num].noGravity = true;
                }
            }
            int num2 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, 169, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num2].scale = 1.5f;
            Main.dust[num2].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
            Main.dust[num2].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
            Main.dust[num2].velocity *= 0.4f;

            if (Player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendData(62, -1, -1, null, Player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
            }
        }
        public double HurtOld(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false, int cooldownCounter = -1)
        {
            return 0.0;
        }

        public double Hurt(PlayerDeathReason damageSource, int Damage, int hitDirection, bool pvp = false, bool quiet = false, bool Crit = false, int cooldownCounter = -1)
        {
            bool flag = !Player.immune;
            //bool flag2 = false;
            int hitContext = cooldownCounter;
            if (cooldownCounter == 0)
            {
                flag = (Player.hurtCooldowns[cooldownCounter] <= 0);
            }
            if (cooldownCounter == 1)
            {
                flag = (Player.hurtCooldowns[cooldownCounter] <= 0);
            }
            if (cooldownCounter == 2)
            {
                //flag2 = true;
                cooldownCounter = -1;
            }
            if (!flag)
            {
                return 0.0;
            }
            bool flag3 = false;
            //bool flag4 = true;
            //bool flag5 = true;
            //if (!PlayerLoader.PreHurt(Player, pvp, quiet, ref Damage, ref hitDirection, ref Crit, ref flag3, ref flag4, ref flag5, ref damageSource))
            //{
            //    return 0.0;
            //}
            if (Main.netMode == 1)
            {
                NetMessage.SendData(84, -1, -1, null, Player.whoAmI, 0f, 0f, 0f, 0, 0, 0);
            }
            int num = Damage;
            double num2 = flag3
             ? (double)num
             : Math.Max(1, num - Player.statDefense / 2);

            if (Player.whoAmI == Main.myPlayer && this.algidityBelt && Main.rand.Next(10) == 0)
            {
                AlgidityDodge();
                return 0.0;
            }
            if (cooldownCounter == -1)
            {
                Player.immune = true;
                if (num2 == 1.0)
                {
                    Player.immuneTime = 20;
                    if (Player.longInvince)
                    {
                        Player.immuneTime += 20;
                    }
                }
                else
                {
                    Player.immuneTime = 40;
                    if (Player.longInvince)
                    {
                        Player.immuneTime += 40;
                    }
                }
                if (pvp)
                {
                    Player.immuneTime = 8;
                }
            }
            else if (cooldownCounter == 0)
            {
                if (num2 == 1.0)
                {
                    Player.hurtCooldowns[cooldownCounter] = (Player.longInvince ? 40 : 20);
                }
                else
                {
                    Player.hurtCooldowns[cooldownCounter] = (Player.longInvince ? 80 : 40);
                }
            }
            else if (cooldownCounter == 1)
            {
                if (num2 == 1.0)
                {
                    Player.hurtCooldowns[cooldownCounter] = (Player.longInvince ? 40 : 20);
                }
                else
                {
                    Player.hurtCooldowns[cooldownCounter] = (Player.longInvince ? 80 : 40);
                }
            }
            return num2;
        }
        public void DashMovement()
        {
            if (IceDash == 1)
            {
                for (int k = 0; k < 2; k++)
                {
                    int num12;
                    if (Player.velocity.Y == 0f)
                    {
                        num12 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)Player.height - 4f), Player.width, 8, 229, 0f, 0f, 100, default(Color), 1.4f);
                    }
                    else
                    {
                        num12 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)(Player.height / 2) - 8f), Player.width, 16, 229, 0f, 0f, 100, default(Color), 1.4f);
                    }
                    Main.dust[num12].velocity *= 0.1f;
                    Main.dust[num12].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                    Main.dust[num12].shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
                }
            }
        }
        #endregion
    }
}
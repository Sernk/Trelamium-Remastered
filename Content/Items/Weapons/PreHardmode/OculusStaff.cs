using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class OculusStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Oculus Staff");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 26;
            Item.height = 28;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 4.5f;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.UseSound = SoundID.Item44;
            Item.shootSpeed = 10f;
            //item.shoot = ModContent.ProjectileType<OpticalPulseProjectile>();
        }
    }
}
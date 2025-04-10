using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Mounts.PreHardmode
{
    public class EyeofCthulhuKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eye of Cthulhu Cart Key");
            // Tooltip.SetDefault("Summons a rideable Eye of Cthulhu Cart");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            Item.rare = -12;
            Item.UseSound = SoundID.Item79;
            Item.mountType = ModContent.MountType<EoCMinecart>();
            Item.noMelee = true;
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TrelamiumRemastered.Content.Items.Memes.RubberDuck
{
    [AutoloadEquip(EquipType.Wings)]
    public class RubberDucksWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rubber Duck's Wings");
            //Tooltip.SetDefault("Allows flight and slow fall"
            //    + "\nHigh Velocity"
            //    + "\nLong Flight Time");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(360, 12f, 2.95f);
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.value = 0;
            Item.rare = 8;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 360;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.95f;
            ascentWhenRising = 0.35f;
            maxCanAscendMultiplier = 1.5f;
            maxAscentMultiplier = 3.5f;
            constantAscend = 0.175f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 12f;
            acceleration *= 2.95f;
        }
    }
}
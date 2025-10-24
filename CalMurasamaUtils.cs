using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CalMurasama
{
    public static partial class CalMurasamaUtils
    {
        public static Rectangle GetCurrentFrame(this Item item, ref int frame, ref int frameCounter, int frameDelay, int frameAmt, bool frameCounterUp = true)
        {
            if (frameCounter >= frameDelay)
            {
                frameCounter = -1;
                frame = frame == frameAmt - 1 ? 0 : frame + 1;
            }
            if (frameCounterUp)
                frameCounter++;
            return new Rectangle(0, item.height * frame, item.width, item.height);
        }

        public static bool CantUseHoldout(this Player player, bool needsToHold = true) => player == null || !player.active || player.dead || (!player.channel && needsToHold) || player.CCed || player.noItems;

        public static bool Organic(this NPC target)
        {
            if (target.HitSound != SoundID.NPCHit4 && target.HitSound != SoundID.NPCHit41 && target.HitSound != SoundID.NPCHit2 &&
                target.HitSound != SoundID.NPCHit5 && target.HitSound != SoundID.NPCHit11 && target.HitSound != SoundID.NPCHit30 &&
                target.HitSound != SoundID.NPCHit34 && target.HitSound != SoundID.NPCHit36 && target.HitSound != SoundID.NPCHit42 &&
                target.HitSound != SoundID.NPCHit49 && target.HitSound != SoundID.NPCHit52 && target.HitSound != SoundID.NPCHit53 &&
                target.HitSound != SoundID.NPCHit54 && target.HitSound != null)
            {
                return true;
            }
            return false;
        }

        public static Item ActiveItem(this Player player) => Main.mouseItem.IsAir ? player.HeldItem : Main.mouseItem;
    }
}

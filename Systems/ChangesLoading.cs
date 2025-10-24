using CalMurasama.Particles;
using Terraria;
using Terraria.ModLoader;

namespace CalMurasama.Systems
{
    public partial class ChangesLoading : ModSystem
    {
        public override void OnModLoad()
        {
            On_Main.DrawInfernoRings += DrawForegroundParticles;
        }

        #region General Particle Rendering

        public static void DrawForegroundParticles(On_Main.orig_DrawInfernoRings orig, Main self)
        {
            GeneralParticleHandler.DrawAllParticles(Main.spriteBatch);
            orig(self);
        }
        
        #endregion
    }
}
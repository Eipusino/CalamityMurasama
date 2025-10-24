using CalMurasama.Particles;
using Terraria;
using Terraria.ModLoader;

namespace CalMurasama.Systems
{
    public class EntityUpdateInterceptionSystem : ModSystem
    {
        #region Particles updating
        public override void PostUpdateEverything()
        {
            if (!Main.dedServ)
                GeneralParticleHandler.Update();
        }
        #endregion
    }
}
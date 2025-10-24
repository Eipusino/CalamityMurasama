using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalMurasama.Particles;
using Terraria;
using Terraria.ModLoader;

namespace CalMurasama
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class CalMurasama : Mod
	{
		public override void Load()
		{
			if (!Main.dedServ)
			{
				GeneralParticleHandler.Load();
			}
		}

		public override void Unload()
		{
			if (!Main.dedServ)
			{
				GeneralParticleHandler.Unload();
			}
		}

		public override void PostSetupContent()
		{
			if (!Main.dedServ) {
				GeneralParticleHandler.LoadModParticleInstances();
			}
		}
    }
}

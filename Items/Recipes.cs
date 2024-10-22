using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalMurasama.Items
{
	public class Recipes : ModSystem
	{
		public override void AddRecipes() {
            Recipe.Create(ModContent.ItemType<Items.Murasama>())
                .AddIngredient(ItemID.TinShortsword)
				.Register();
            Recipe.Create(ModContent.ItemType<Items.Murasama>())
                .AddIngredient(ItemID.IronShortsword)
                .Register();
		}

	}
}

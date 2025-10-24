using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalMurasama.Items
{
    internal class RecipeSystem : ModSystem
    {
        public override void AddRecipes() {
            Recipe.Create(ModContent.ItemType<Murasama>())
                .AddIngredient(ItemID.BrokenHeroSword)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

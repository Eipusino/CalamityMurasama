using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalMurasama.Systems
{
    internal class RecipeSystem : ModSystem
    {
        public override void AddRecipes() {
            Recipe.Create(ModContent.ItemType<Items.Murasama>())
                .AddIngredient(ItemID.BrokenHeroSword)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

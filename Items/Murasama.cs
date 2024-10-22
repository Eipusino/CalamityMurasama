using CalMurasama.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalMurasama.Items
{
    public class Murasama : ModItem
    {

        public int frameCounter = 0;
        public int frame = 0;
        public bool IDUnlocked(Player player) => true;

        public static readonly SoundStyle OrganicHit = new("CalMurasama/Sounds/MurasamaHitOrganic") { Volume = 0.45f };
        public static readonly SoundStyle InorganicHit = new("CalMurasama/Sounds/MurasamaHitInorganic") { Volume = 0.55f };
        public static readonly SoundStyle Swing = new("CalMurasama/Sounds/MurasamaSwing") { Volume = 0.2f };
        public static readonly SoundStyle BigSwing = new("CalMurasama/Sounds/MurasamaBigSwing") { Volume = 0.25f };
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 13));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 90;
            Item.height = 134;
            Item.damage = 1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 5;
            Item.knockBack = 6.5f;
            Item.autoReuse = false;
            Item.value = 0 ;
            Item.shoot = ModContent.ProjectileType<MurasamaSlash>();
            Item.shootSpeed = 24f;
            Item.rare = ItemRarityID.Cyan;
        }

        // Terraria seems to really dislike high crit values in SetDefaults

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture;

            if (IDUnlocked(Main.LocalPlayer))
            {
                //0 = 6 frames, 8 = 3 frames]
                texture = ModContent.Request<Texture2D>(Texture).Value;
                spriteBatch.Draw(texture, position, Item.GetCurrentFrame(ref frame, ref frameCounter, 2, 13), Color.White, 0f, origin, scale, SpriteEffects.None, 0);
            }
            else
            {
                texture = ModContent.Request<Texture2D>("CalMurasama/Items/MurasamaSheathed").Value;
                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
            }

            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture;

            if (IDUnlocked(Main.LocalPlayer))
            {
                texture = ModContent.Request<Texture2D>(Texture).Value;
                spriteBatch.Draw(texture, Item.position - Main.screenPosition, Item.GetCurrentFrame(ref frame, ref frameCounter, 2, 13), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            else
            {
                texture = ModContent.Request<Texture2D>("CalMurasama/Items/MurasamaSheathed").Value;
                spriteBatch.Draw(texture, Item.position - Main.screenPosition, null, lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!IDUnlocked(Main.LocalPlayer))
                return;
            Texture2D texture = ModContent.Request<Texture2D>("CalMurasama/Items/MurasamaGlow").Value;
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, Item.GetCurrentFrame(ref frame, ref frameCounter, 2, 13, false), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[Item.shoot] > 0)
                return false;
            return IDUnlocked(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperShortsword);
            recipe.Register();
        }



    }
}

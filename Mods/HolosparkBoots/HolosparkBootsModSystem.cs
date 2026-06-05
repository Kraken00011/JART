using System.Collections.Generic;
using System.Globalization;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class HolosparkBootsModSystem : ModSystem
{
    public override void PostAddRecipes()
    {
        if (!ModLoader.TryGetMod("HolosparkBoots", out var holospark)) return;
        if (!ModLoader.TryGetMod("CalamityMod", out var cal)) return;

        bool hasIE = ModLoader.TryGetMod("InfernalEclipseAPI", out var ie);
        bool hasRag = ModLoader.TryGetMod("RagnarokMod", out var rag);

        if (!hasIE && !hasRag) return;

        if (!holospark.TryFind<ModItem>("HolosparkBoots", out var holosparkBoots)) return;
        if (!cal.TryFind<ModItem>("AngelTreads", out var angelTreads)) return;

        foreach (Recipe recipe in Main.recipe)
        {
            if (recipe == null) continue;

            if (recipe.HasIngredient(holosparkBoots.Type))
            {
                recipe.DisableRecipe();
                continue;
            }

            if (recipe.HasIngredient(angelTreads.Type))
            {
                recipe.RemoveIngredient(angelTreads.Type);
                recipe.AddIngredient(holosparkBoots.Type, 1);
                continue;
            }

            if (recipe.HasResult(holosparkBoots.Type) && recipe.HasIngredient(ItemID.TerrasparkBoots))
            {
                recipe.RemoveIngredient(ItemID.TerrasparkBoots);
                recipe.AddIngredient(angelTreads.Type, 1);
            }
        }
    }
}
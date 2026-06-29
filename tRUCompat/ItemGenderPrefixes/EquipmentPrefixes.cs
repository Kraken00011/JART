using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;
using Microsoft.Xna.Framework;

public class EquipmentPrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("EquipmentReforge") && ModLoader.HasMod("CalamityRuTranslate") && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);

        // Сортировал по ID!!!
        if (TRuConfig.Instance.VanillaLocalization)
        {
            tru.Call("AddVanillaFeminineItems", new int[]
            {
            });

            tru.Call("AddVanillaNeuterItems", new int[]
            {
            });

            tru.Call("AddVanillaPluralItems", new int[]
            {
            });
        }
    }
}
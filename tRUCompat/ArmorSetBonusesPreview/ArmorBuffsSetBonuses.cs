using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class ArmorBuffsSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.ArmorBuffsLocalization && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("ArmorBuffs", out Mod armorBuff);

        if (tru != null && armorBuff != null)
        {
            tru.Call("AddArmorSetBonusPreview", (int)ItemID.ArchaeologistsHat, (Func<string>)(() =>
                Language.GetTextValue("Mods.ArmorBuffs.Sets.Archaeologist")
            ));

            tru.Call("AddArmorSetBonusPreview", (int)ItemID.RuneHat, (Func<string>)(() =>
                Language.GetTextValue("Mods.ArmorBuffs.Sets.Rune")
            ));
        }
    }
}
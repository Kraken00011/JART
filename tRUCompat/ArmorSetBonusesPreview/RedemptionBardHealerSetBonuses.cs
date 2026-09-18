using System;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Core.Config;

internal class RedemptionBardHealerSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.RedemptionBardHealerLocalization;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("RedemptionBardHealer", out Mod redemptionBardHealer);

        if (tru != null && redemptionBardHealer != null)
        {
            tru.Call("AddArmorSetBonusPreview", redemptionBardHealer.Find<ModItem>("HardlightMask").Type, (Func<string>)(() =>
            {
                string bonus = Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Press") +
                               "[Особая способность]" +
                               Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Support") +
                               Language.GetTextValue("Mods.RedemptionBardHealer.Items.HardlightMask.SetBonus");

                return bonus;
            }));

            tru.Call("AddArmorSetBonusPreview", redemptionBardHealer.Find<ModItem>("HardlightReticle").Type, (Func<string>)(() =>
            {
                string bonus = Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Press") +
                               "[Особая способность]" +
                               Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Support") +
                               Language.GetTextValue("Mods.RedemptionBardHealer.Items.HardlightReticle.SetBonus");

                return bonus;
            }));

            tru.Call("AddArmorSetBonusPreview", redemptionBardHealer.Find<ModItem>("HardlightVisage").Type, (Func<string>)(() =>
            {
                string bonus = Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Press") +
                               "[Особая способность]" +
                               Language.GetTextValue("Mods.Redemption.GenericTooltips.ArmorSetBonus.Hardlight.Support") +
                               Language.GetTextValue("Mods.RedemptionBardHealer.Items.HardlightVisage.SetBonus");

                return bonus;
            }));
        }
    }
}
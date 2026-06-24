using System;
using Terraria.Localization;
using Terraria.ModLoader;
using CatalystMod;
using Terraria.GameInput;
using ThoriumMod;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

internal class CalamityBardHealerSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.CalamityBardHealerLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("CalamityBardHealer", out Mod calBardHealer);

        if (tru != null && calBardHealer != null)
        {
            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AerospecBiretta").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.AerospecBiretta.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AerospecHeadphones").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.AerospecHeadphones.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AugmentedAuricTeslaFeatheredHeadwear").Type, (Func<string>)(() =>
            {
                var keys = CatalystPlayer.AsteroidVisToggleKey.GetAssignedKeys((InputMode)0);
                string hotkeyStr = keys.Count > 0
                    ? Language.GetTextValue("Mods.CatalystMod.Common.BoundKey", keys[0])
                    : Language.GetTextValue("Mods.CatalystMod.Common.UnboundKey");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.AugmentedAuricTeslaFeatheredHeadwear.SetBonus", hotkeyStr);
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AugmentedAuricTeslaValkyrieVisage").Type, (Func<string>)(() =>
            {
                var keys = CatalystPlayer.AsteroidVisToggleKey.GetAssignedKeys((InputMode)0);
                string hotkeyStr = keys.Count > 0
                    ? Language.GetTextValue("Mods.CatalystMod.Common.BoundKey", keys[0])
                    : Language.GetTextValue("Mods.CatalystMod.Common.UnboundKey");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.AugmentedAuricTeslaValkyrieVisage.SetBonus", hotkeyStr);
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AuricTeslaFeatheredHeadwear").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.AuricTeslaFeatheredHeadwear.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AuricTeslaValkyrieVisage").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.AuricTeslaValkyrieVisage.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("BloodflareRitualistMask").Type, (Func<string>)(() =>
            {
                var armorKey = ThoriumHotkeySystem.ArmorKey;
                var assignedKeys = armorKey.GetAssignedKeys((InputMode)0);

                string keyText = "";
                for (int i = 0; i < assignedKeys.Count; i++)
                    keyText = i >= assignedKeys.Count - 1
                        ? keyText + assignedKeys[i]
                        : keyText + assignedKeys[i] + ", ";

                int healBonus = 12;

                return Language.GetText("Mods.CalamityBardHealer.Items.BloodflareRitualistMask.SetBonus")
                    .Format(keyText, healBonus)
                    .ToString() + "\n" + Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.BloodflareBodyArmor.CommonSetBonus");
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("BloodflareSirenSkull").Type, (Func<string>)(() =>
            {
                var armorKey = ThoriumHotkeySystem.ArmorKey;
                var assignedKeys = armorKey.GetAssignedKeys((InputMode)0);

                string keyText = "";
                for (int i = 0; i < assignedKeys.Count; i++)
                    keyText = i >= assignedKeys.Count - 1
                    ? keyText + assignedKeys[i]
                    : keyText + assignedKeys[i] + ", ";

                return Language.GetText("Mods.CalamityBardHealer.Items.BloodflareSirenSkull.SetBonus")
                    .Format(keyText)
                    .ToString() + "\n" + Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.BloodflareBodyArmor.CommonSetBonus");
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("DaedalusCowl").Type, (Func<string>)(() =>
            {
                var armorKey = ThoriumHotkeySystem.ArmorKey;
                var assignedKeys = armorKey.GetAssignedKeys((InputMode)0);

                string keyText = "";
                for (int i = 0; i < assignedKeys.Count; i++)
                    keyText = i >= assignedKeys.Count - 1
                    ? keyText + assignedKeys[i]
                    : keyText + assignedKeys[i] + ", ";

                return Language.GetText("Mods.CalamityBardHealer.Items.DaedalusCowl.SetBonus")
                .Format(keyText, 4)
                .ToString();
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("DaedalusHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.DaedalusHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("SilvaGuardianHelmet").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.SilvaGuardianHelmet.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("StatigelFoxMask").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.StatigelFoxMask.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("TarragonChapeau").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.TarragonChapeau.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("TarragonParagonCrown").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.TarragonParagonCrown.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("VictideAmmoniteHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.VictideAmmoniteHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("VoidFaquirBiretta").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.VoidFaquirBiretta.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("VoidFaquirChapeau").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.VoidFaquirChapeau.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("IntergelacticCloche").Type, (Func<string>)(() =>
            {
                string intergelacticAll = Language.GetTextValue("Mods.CatalystMod.ArmorSetBonus.IntergelacticAll", "[Межгелектический бонус комплекта]");
                string intergelacticRadiant = Language.GetTextValue("Mods.CalamityBardHealer.Items.IntergelacticCloche.SetBonus");

                return $"{intergelacticAll}\n{intergelacticRadiant}";
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("IntergelacticProtectorHelm").Type, (Func<string>)(() =>
            {
                string intergelacticAll = Language.GetTextValue("Mods.CatalystMod.ArmorSetBonus.IntergelacticAll", "[Межгелектический бонус комплекта]");
                string intergelacticSymphonic = Language.GetTextValue("Mods.CalamityBardHealer.Items.IntergelacticProtectorHelm.SetBonus");

                return $"{intergelacticAll}\n{intergelacticSymphonic}";
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("HydrothermicHat").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.HydrothermicHat.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("HydrothermicGasMask").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.HydrothermicGasMask.SetBonus")
            ));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("GodSlayerDeathsingerCowl").Type, (Func<string>)(() =>
                Language.GetTextValue("Mods.CalamityBardHealer.Items.GodSlayerDeathsingerCowl.SetBonus")
            ));
        }
    }
}
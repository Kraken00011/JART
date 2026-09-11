using System;
using Terraria.Localization;
using Terraria.ModLoader;
using CatalystMod;
using Terraria.GameInput;
using ThoriumMod;
using JAtRT.Core.Config;
using CalamityRuTranslate.Core.Config;

internal class CalamityBardHealerSetBonuses : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => JARTLocalizationConf.Instance.CalamityBardHealerLocalization && TRuConfig.Instance.ArmorSetBonusPreview;
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("CalamityBardHealer", out Mod calBardHealer);

        if (tru != null && calBardHealer != null)
        {
            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AerospecBiretta").Type, (Func<string>)(() =>
            {
                string aerospecCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PreHardmode.AerospecBreastplate.CommonSetBonus", 25);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.AerospecBiretta.SetBonus") + "\n" + aerospecCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("AerospecHeadphones").Type, (Func<string>)(() =>
            {
                string aerospecCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PreHardmode.AerospecBreastplate.CommonSetBonus", 25);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.AerospecHeadphones.SetBonus") + "\n" + aerospecCommon;
            }));

            if (ModLoader.HasMod("CatalystMod"))
            {
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
            }

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
            {
                object[] args = [3, 5, 5, 5];
                string silvaCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.SilvaArmor.CommonSetBonus", args);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.SilvaGuardianHelmet.SetBonus") + "\n" + silvaCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("StatigelFoxMask").Type, (Func<string>)(() =>
            {
                string statigelCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PreHardmode.StatigelArmor.CommonSetBonus", 12);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.StatigelFoxMask.SetBonus") + "\n" + statigelCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("StatigelEarrings").Type, (Func<string>)(() =>
            {
                string statigelCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PreHardmode.StatigelArmor.CommonSetBonus", 12);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.StatigelFoxMask.SetBonus") + "\n" + statigelCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("TarragonChapeau").Type, (Func<string>)(() =>
            {
                string tarragonCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.TarragonBreastplate.CommonSetBonus");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.TarragonChapeau.SetBonus") + "\n" + tarragonCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("TarragonParagonCrown").Type, (Func<string>)(() =>
            {
                string tarragonCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.TarragonBreastplate.CommonSetBonus");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.TarragonParagonCrown.SetBonus") + "\n" + tarragonCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("VictideAmmoniteHat").Type, (Func<string>)(() =>
            {
                string victideCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PreHardmode.VictideBreastplate.CommonSetBonus");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.VictideAmmoniteHat.SetBonus") + "\n" + victideCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("HydrothermicHat").Type, (Func<string>)(() =>
            {
                string hydrothermicCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.Hardmode.HydrothermicArmor.CommonSetBonus");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.HydrothermicHat.SetBonus") + "\n" + hydrothermicCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("HydrothermicGasMask").Type, (Func<string>)(() =>
            {
                string hydrothermicCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.Hardmode.HydrothermicArmor.CommonSetBonus");

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.HydrothermicGasMask.SetBonus") + "\n" + hydrothermicCommon;
            }));

            tru.Call("AddArmorSetBonusPreview", calBardHealer.Find<ModItem>("GodSlayerDeathsingerCowl").Type, (Func<string>)(() =>
            {
                object[] args = ["[Простанственный скачок]", 45];
                string godSlayerCommon = Language.GetTextValue("Mods.CalamityMod.Items.Armor.PostMoonLord.GodSlayerChestplate.CommonSetBonus", args);

                return Language.GetTextValue("Mods.CalamityBardHealer.Items.GodSlayerDeathsingerCowl.SetBonus") + "\n" + godSlayerCommon;
            }));
        }
    }
}
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class MunchiesVanillaNamePatch : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("Munchies") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.MunchiesLocalization;

    public override void PostSetupContent()
    {
        if (!ModLoader.TryGetMod("Munchies", out var munchies))
            return;

        var reportType = munchies.Code.GetType("Munchies.Models.Report");
        if (reportType == null) return;

        var field = reportType.GetField("VanillaConsumableMod",
            BindingFlags.Public | BindingFlags.Static);
        if (field == null) return;

        var current = field.GetValue(null);
        var nameField = current.GetType().GetField("ModTabName", BindingFlags.Public | BindingFlags.Instance);

        nameField?.SetValue(current, "Ванилла");
    }
}
using System;
using System.Reflection;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public class BeaconMapLayerPatch : ILPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("BeamStopsSpread") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.BeamStopsSpreadLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("BeamStopsSpread", out var mod))
                return null;

            var type = mod.Code.GetType("BeamStopsSpread.Scripts.BeaconMapLayer");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] BeamStopsSpread/BeaconMapLayerPatch: тип не найден!");
                return null;
            }

            return type.GetMethod("Draw", BindingFlags.Instance | BindingFlags.Public);
        }
    }

    public override ILContext.Manipulator PatchMethod => il =>
    {
        var cursor = new ILCursor(il);

        var translations = new System.Collections.Generic.Dictionary<string, string>
        {
            { "Crimson Beacon", "Маяк багрянца" },
            { "Corruption Beacon", "Маяк искажения" },
            { "Hallow Beacon", "Маяк освящения" },
            { "Confection Beacon", "Маяк сладкоземья" },
            { "Disconnected Connector", "Отключённый соединитель" },
            { "Hallow Connector", "Освящённый соединитель" },
            { "Corruption Connector", "Искажённый соединитель" },
            { "Crimson Connector", "Багрянцевый соединитель" },
            { "Confection Connector", "Сладкоземный соединитель" }
        };

        foreach (var (original, translated) in translations)
        {
            cursor.Goto(0);
            bool found = false;
            while (cursor.TryGotoNext(i => i.MatchLdstr(original)))
            {
                cursor.Next.Operand = translated;
                found = true;
            }
        }
    };
}
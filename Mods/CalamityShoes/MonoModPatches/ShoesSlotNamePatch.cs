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

public class CalamityShoesSlotPatch : OnPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("CalamityShoes") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.CalamityShoesLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("CalamityShoes", out var mod))
                return null;

            var type = mod.Code.GetType("CalamityShoes.Common.Players.ShoeSlot");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] CalamityShoes/ShoesSlotNamePatch: тип не найден!");
                return null;
            }

            return type.GetMethod("OnMouseHover",
                BindingFlags.Instance | BindingFlags.Public);
        }
    }

    private delegate void OnMouseHoverDelegate(ModAccessorySlot self, AccessorySlotType context);

    public override Delegate Delegate => (OnMouseHoverDelegate)((self, context) =>
    {
        switch ((int)context)
        {
            case 10: // Слот аксессуара
                Main.hoverItemName = "Ботинки";
                break;
            case 11: // Слот украшения
                Main.hoverItemName = "Внешний вид: Ботинки";
                break;
            case 12: // Краситель
                Main.hoverItemName = "Краситель";
                break;
        }
    });
}
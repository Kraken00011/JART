using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

public class ShoeSlotSlotPatch : OnPatcher
{
    public override bool AutoLoad => ModLoader.HasMod("ShoeSlot") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.ShoeSlotLocalization;

    public override MethodBase ModifiedMethod
    {
        get
        {
            if (!ModLoader.TryGetMod("ShoeSlot", out var mod))
                return null;

            var type = mod.Code.GetType("ShoeSlot.Common.UI.ShoeSlot");
            if (type == null)
            {
                Logging.PublicLogger.Warn("[JAtRT] ShoeSlot/ShoeSlotNamePatch: тип не найден!");
                return null;
            }

            return type.GetMethod("OnMouseHover",
                BindingFlags.Instance | BindingFlags.Public);
        }
    }

    private delegate void OnMouseHoverDelegate(ModAccessorySlot self, AccessorySlotType context);

    public override Delegate Delegate => (OnMouseHoverDelegate)((self, context) =>
    {
        switch ((int)context - 10)
        {
            case 0: // Аксессуар
                Main.hoverItemName = "Ботинки";
                break;
            case 1: // Внешний вид
                Main.hoverItemName = "Внешний вид: Ботинки";
                break;
            case 2: // Краситель
                Main.hoverItemName = "Краситель";
                break;
        }
    });
}
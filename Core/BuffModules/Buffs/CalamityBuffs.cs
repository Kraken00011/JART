using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace JAtRT.Core.BuffModules
{
    public static class CalamityColors
    {
        private static MethodInfo _method;
        private static bool _searched;

        public static Color? TypeColor(int buffId)
        {
            if (!_searched)
            {
                _searched = true;
                if (ModLoader.TryGetMod("CalamityMod", out var cal))
                    _method = cal.Code?.GetType("CalamityMod.CalamityUtils")?.GetMethod(
                        "GetDebuffTooltipNameColor",
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static,
                        null, new[] { typeof(int) }, null);
            }

            if (_method == null)
                return null;

            try { return (Color)_method.Invoke(null, new object[] { buffId }); }
            catch { return null; }
        }

        public static BuffInfoRegistry.Entry IgnoreCalamityColor(this BuffInfoRegistry.Entry e)
            => e.IgnoreColorFrom("CalamityMod");
    }

    public class CalamityBuffs : BuffInfoModule
    {
        public override string ModName => "CalamityMod";

        public override void Register()
        {
            BuffInfoRegistry.RegisterColorProvider("CalamityMod", CalamityColors.TypeColor);

            // BuffInfoRegistry.Register("CalamityMod", "Plague", new Color(80, 200, 80)).IgnoreCalamityColor();

            // BuffInfoRegistry.RegisterItem("CalamityMod", "Murasama").Enemy("CalamityMod", "Plague");
        }
    }
}

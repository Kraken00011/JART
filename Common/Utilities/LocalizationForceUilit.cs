using System.Reflection;
using Terraria.Localization;

namespace JAtRT.Common.Utilities
{
    public static class LocalizationForceUtils
    {
        private static readonly FieldInfo ValueField = typeof(LocalizedText).GetField("_value", BindingFlags.Instance | BindingFlags.NonPublic);

        public static void ForceSet(this LocalizedText text, string value)
        {
            ValueField?.SetValue(text, value);
        }
    }
}

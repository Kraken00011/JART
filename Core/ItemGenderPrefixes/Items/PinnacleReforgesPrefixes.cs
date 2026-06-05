using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

namespace JAtRT.Core.ItemPrefixes.Items
{
    internal class PinnacleReforgesPrefixes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("PinnacleReforges") && ModLoader.HasMod("CalamityRuTranslate") && Language.ActiveCulture.Name == "ru-RU";
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);

            RegisterPinnacleReforges(tru);
        }

        private void RegisterPinnacleReforges(Mod tru)
        {
            ModLoader.TryGetMod("PinnacleReforges", out _);

            tru.Call("RegisterPrefixes", PinnacleReforges);

            tru.Call("AddFeminineItems", new string[]
            {
                "Rune"
            });
        }

        private static readonly List<string[]> PinnacleReforges = new()
        {
            new[] { "Точный", "Точная", "Точное", "Точные" },
            new[] { "Автоматизированный", "Автоматизированная", "Автоматизированное", "Автоматизированные" },
            new[] { "Шквальный", "Шквальная", "Шквальное", "Шквальные" },
            new[] { "Прямолинейный", "Прямолинейная", "Прямолинейное", "Прямолинейные" },
            new[] { "Постоянный", "Постоянная", "Постоянное", "Постоянные" },
            new[] { "Отчаянный", "Отчаянная", "Отчаянное", "Отчаянные" },
            new[] { "Организованный", "Организованная", "Организованное", "Организованные" },
            new[] { "Разрушительный", "Разрушительная", "Разрушительное", "Разрушительные" },
            new[] { "Эффективный", "Эффективная", "Эффективное", "Эффективные" },
        };
    }
}
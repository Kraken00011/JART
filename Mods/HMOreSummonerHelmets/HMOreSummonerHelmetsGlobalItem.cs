using System.Collections.Generic;
using System.Globalization;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class HMOreSummonerHelmetsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModLoader.HasMod("HMOreSummonerHelmets") && JARTLocalizationConf.Instance.HMOreSummonerHelmetsLocalization && Language.ActiveCulture.Name == "ru-RU";
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        ItemHelper.TranslateTooltip(tooltips, "SetBonus", tooltip =>
        {
            Player player = Main.player[Main.myPlayer];
            string setBonusKey = Language.GetTextValue("LegacyTooltip.48");

            if (tooltip.Text == $"{setBonusKey} Flower petals will fall on your target for extra damage\nIncreases your maximum number of minions by 2")
            {
                tooltip.Text = $"{setBonusKey} При нанесении урона выпускает во врагов цветочные лепестки, наносящие дополнительный урон\nУвеличивает максимальное количество миньонов на 2";
            };

            if (tooltip.Text == $"{setBonusKey} Increases your maximum number of minions by 1\nIncreases movement and whip speed by 25%")
            {
                tooltip.Text = $"{setBonusKey} Увеличивает максимальное количество миньонов на 1\nУвеличивает скорость передвижения и хлыстов на 25%";
            };

            if (tooltip.Text == $"{setBonusKey} Greatly increases life regeneration after striking an enemy\nIncreases your maximum number of minions by 2")
            {
                tooltip.Text = $"{setBonusKey} При нанесении урона по врагу сильно увеличивает регенерацию здоровья\nУвеличивает максимальное количество миньонов на 2";
            };

            if (tooltip.Text == $"{setBonusKey} Increases your maximum number of minions by 1\nMinions and sentries have a 20% chance to critically strike")
            {
                tooltip.Text = $"{setBonusKey} Увеличивает максимальное количество миньонов на 1\nДаёт 20% шанс критического удара миньонам и стражам";
            };

            if (tooltip.Text == $"{setBonusKey} Attacking generates a defensive barrier of titanium shards\nIncreases your maximum number of minions by 2")
            {
                tooltip.Text = $"{setBonusKey} При нанесении урона по врагу создаётся защитный барьер из титановых осколков\nУвеличивает максимальное количество миньонов на 2";
            };

            if (tooltip.Text == $"{setBonusKey} Increases your maximum number of minions by 1\nIncreases whip range by 25%")
            {
                tooltip.Text = $"{setBonusKey} Увеличивает максимальное количество миньонов на 1\nУвеличивает дальность хлыстов на 25%";
            };
        });
    }
}
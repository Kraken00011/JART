using System.Collections.Generic;
using System.Globalization;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

public partial class HMOreSummonerHelmetsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("HMOreSummonerHelmets") && JARTLocalizationConf.Instance.HMOreSummonerHelmetsLocalization && Language.ActiveCulture.Name == "ru-RU";
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        ItemHelper.TranslateTooltip(tooltips, "SetBonus", tooltip =>
        {
            string setBonusKey = Language.GetTextValue("LegacyTooltip.48");

            if (tooltip.Text.Contains("Flower petals will fall on your target for extra damage"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.OrichalcumCrown")}";
            }

            else if (tooltip.Text.Contains("Increases movement and whip speed by 25%"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.CobaltKabuto")}";
            }

            else if (tooltip.Text.Contains("Greatly increases life regeneration after striking an enemy"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.PalladiumHelm")}";
            }

            else if (tooltip.Text.Contains("Minions and sentries have a 20% chance to critically strike"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.MythrilCrown")}";
            }

            else if (tooltip.Text.Contains("Attacking generates a defensive barrier of titanium shards"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.TitaniumGrowth")}";
            }
            
            else if (tooltip.Text.Contains("Increases whip range by 25%"))
            {
                tooltip.Text = $"{setBonusKey} {Language.GetTextValue("Mods.JAtRT.HMOreSummonerHelmets.ArmorSetBonuses.AdamantiteHelm")}";
            }
        });
    }
}
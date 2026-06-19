using ContinentOfJourney.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;

public class HomewardRagnarokGlobalBuff : GlobalBuff
{
	public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.HomewardRagnarokLocalization && ModLoader.HasMod("HomewardRagnarok");
	
	public override void ModifyBuffText(int type, ref string displayName, ref string tooltip, ref int drawOffset)
	{
		if (type == ModContent.BuffType<BattaliansBackupBuff>())
		{
			tooltip = tooltip.Replace("Получаемый урон уменьшен на ", "Сопротивление урону увеличено на ");
			tooltip = tooltip.Replace("15", "15 ед.");
			tooltip = tooltip.Replace("Иммунитет к отбрасыванию", "Невосприимчивость к отбрасыванию");
		}

		if (type == ModContent.BuffType<GrayRookBuff>())
		{
			tooltip = tooltip.Replace("расход маны и использование боеприпасов уменьшены на ", "Расход маны и шанс потратить боеприпасы снижены на ");
		}
	}
}

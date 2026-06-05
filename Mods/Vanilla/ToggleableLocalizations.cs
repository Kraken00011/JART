using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using JAtRT.Core.MonoMod;
using Hjson;
using Newtonsoft.Json.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

namespace JAtRT.Mods.Vanilla;

public class ToggleableLocalizations : OnPatcher
{
	private static HashSet<string> _customKeys = new();

	public override bool AutoLoad => TranslationHelper.IsRussianLanguage;

	public override MethodInfo ModifiedMethod => typeof(LocalizationLoader).FindMethod("LoadTranslations", [typeof(TmodFile), typeof(GameCulture)
	]);

	private delegate List<(string key, string value)> LoadTranslationsDelegate(TmodFile tModFile, GameCulture culture);

	public override Delegate Delegate => Translation;

	private List<(string key, string value)> Translation(LoadTranslationsDelegate orig, TmodFile tModFile, GameCulture culture)
	{
		if (culture != GameCulture.FromCultureName(GameCulture.CultureName.Russian))
			return orig.Invoke(tModFile, culture);

		if (tModFile == null)
			return new();

		Type type = typeof(Mod).Assembly.GetType("Terraria.ModLoader.Core.BuildProperties");
		MethodInfo readModFile = type.FindMethod("ReadModFile");
		object properties = readModFile.Invoke(null, [tModFile]);
		string modSourceField = properties.GetMemberValue<string>("modSource");
		string sourceFolder = Directory.Exists(modSourceField) ? modSourceField : "";
		try
		{
			List<(string, string)> flattened = new();
			static bool Skip(bool configEnabled, string modName, string modpath, string targetPath)
				=> (!configEnabled || !ModLoader.HasMod(modName)) && modpath == targetPath;
			foreach (TmodFile.FileEntry translationFile in tModFile.Where(entry => Path.GetExtension(entry.Name) == ".hjson"))
			{
				string modpath = Path.Combine(tModFile.Name, translationFile.Name).Replace('/', '\\');

				if (!LocalizationLoader.TryGetCultureAndPrefixFromPath(translationFile.Name, out GameCulture fileCulture, out string prefix))
					continue;

				if (fileCulture != culture)
					continue;

				// Enchanted Moons
				if (Skip(JARTLocalizationConf.Instance.BlueMoonLocalization, "BlueMoon",
				modpath, @"JAtRT\Localization\BlueMoon\ru-RU_Mods.BlueMoon.hjson"))
					continue;

				// Boss Cursor
				if (Skip(JARTLocalizationConf.Instance.BossCursorLocalization, "BossCursor",
				modpath, @"JAtRT\Localization\BossCursor\ru-RU_Mods.BossCursor.hjson"))
					continue;

				// Calamity Crossmod Vulnerabilities
				if (Skip(JARTLocalizationConf.Instance.CalamityCrossmodVulnerabilitiesLocalization, "CalamityCrossmodVulnerabilities",
				modpath, @"JAtRT\Localization\CalamityCrossmodVulnerabilities\ru-RU_Mods.CalamityCrossmodVulnerabilities.hjson"))
					continue;

				// Hunt of the Old God
				if (Skip(JARTLocalizationConf.Instance.CalamityHuntFix, "CalamityHunt",
				modpath, @"JAtRT\Localization\CalamityHunt\ru-RU_Mods.CalamityHunt.hjson"))
					continue;

				// Better Zenith in Calamity
				if (Skip(JARTLocalizationConf.Instance.CalamityZenithLocalization, "calamityzenith",
				modpath, @"JAtRT\Localization\calamityzenith\ru-RU_Mods.calamityzenith.hjson"))
					continue;

				// Clamity Addon
				if (Skip(JARTLocalizationConf.Instance.ClamityFix, "Clamity",
				modpath, @"JAtRT\Localization\Clamity\ru-RU_Mods.Clamity.hjson"))
					continue;

				// Clamity Music
				if (Skip(JARTLocalizationConf.Instance.ClamityMusicLocalization, "ClamityMusic",
				modpath, @"JAtRT\Localization\ClamityMusic\ru-RU_Mods.ClamityMusic.hjson"))
					continue;

				// Corruption Core Boss
				if (!JARTLocalizationConf.Instance.CorruptionBossLocalization
				&& modpath == @"JAtRT\Localization\CorruptionBoss\ru-RU_Mods.CorruptionBoss.hjson")
					continue;

				// Discordya
				if (!JARTLocalizationConf.Instance.DiscordyaLocalization
				&& modpath == @"JAtRT\Localization\Discordya\ru-RU_Mods.Discordya.hjson")
					continue;

				// Evil Bosses Rework
				if (!JARTLocalizationConf.Instance.EvilBossesReworkLocalization
				&& modpath == @"JAtRT\Localization\EvilBossesRework\ru-RU_Mods.EvilBossesRework.hjson")
					continue;

				// More Pylons
				if (!JARTLocalizationConf.Instance.EvilPylonLocalization
				&& modpath == @"JAtRT\Localization\EvilPylon\ru-RU_Mods.EvilPylon.hjson")
					continue;

				// Fancy Whips
				if (!JARTLocalizationConf.Instance.FancyWhipsLocalization
				&& modpath == @"JAtRT\Localization\FancyWhips\ru-RU_Mods.FancyWhips.hjson")
					continue;

				// Unofficial Fargo's Souls Pets
				if (!JARTLocalizationConf.Instance.FargoUnofficialPetsLocalization
				&& modpath == @"JAtRT\Localization\FargoUnofficialPets\ru-RU_Mods.FargoUnofficialPets.hjson")
					continue;

				// Calamity - Fargo's Souls DLC
				if (!JARTLocalizationConf.Instance.FargowiltasCrossmodFix
				&& modpath == @"JAtRT\Localization\FargowiltasCrossmod\ru-RU_Mods.FargowiltasCrossmod.hjson")
					continue;

				// Jungle Bosses Rework
				if (!JARTLocalizationConf.Instance.GolemReworkLocalization
				&& modpath == @"JAtRT\Localization\GolemRework\ru-RU_Mods.GolemRework.hjson")
					continue;

				// HP Awareness
				if (!JARTLocalizationConf.Instance.HPAwareLocalization
				&& modpath == @"JAtRT\Localization\HPAware\ru-RU_Mods.HPAware.hjson")
					continue;

				// Holospark Boots
				if (!JARTLocalizationConf.Instance.HolosparkBootsLocalization
				&& modpath == @"JAtRT\Localization\HolosparkBoots\ru-RU_Mods.HolosparkBoots.hjson")
					continue;

				// Homeward Ragnarok
				if ((!JARTLocalizationConf.Instance.HomewardRagnarokLocalization || !ModLoader.HasMod("HomewardRagnarok"))
				&& (modpath == @"JAtRT\Localization\HomewardRagnarok\ru-RU_Mods.HomewardRagnarok.hjson"
				|| modpath == @"JAtRT\Localization\HomewardRagnarok\ru-RU_Mods.RevengeancePlus.hjson"))
					continue;

				if (!JARTLocalizationConf.Instance.HomewardSubworldLocalization
				&& modpath == @"JAtRT\Localization\HomewardSubworld\ru-RU_Mods.HomewardSubworld.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.HypnosModLocalization
				&& modpath == @"JAtRT\Localization\HypnosMod\ru-RU_Mods.HypnosMod.hjson")
					continue;

				if (Skip(JARTLocalizationConf.Instance.InfernalEclipseLocalization, "InfernalEclipseAPI",
				modpath, @"JAtRT\Localization\InfernalEclipseAPI\ru-RU_Mods.hjson"))
					continue;

				if (!JARTLocalizationConf.Instance.ToolsPrefixesFix
				&& modpath == @"JAtRT\Localization\InterestingPrefix\ru-RU_Mods.InterestingPrefix.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ItemRelicsLocalization
				&& modpath == @"JAtRT\Localization\ItemRelics\ru-RU_Mods.ItemRelics.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.LifeSourcesLightLocalization
				&& modpath == @"JAtRT\Localization\LifeSourcesLight\ru-RU_Mods.LifeSourcesLight.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MiscellanariaLocalization
				&& modpath == @"JAtRT\Localization\Miscellanaria\ru-RU_Mods.Miscellanaria.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MoreBeamsLocalization
				&& modpath == @"JAtRT\Localization\MoreBeams\ru-RU_Mods.MoreBeams.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SevenItemsFromMinecraftLocalization
				&& modpath == @"JAtRT\Localization\QualityOfGuida\ru-RU_Mods.QualityOfGuida.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ReforgedLocalization
				&& modpath == @"JAtRT\Localization\Reforged\ru-RU_Mods.Reforged.hjson")
					continue;

				if ((!JARTLocalizationConf.Instance.RevengeancePlusLocalization || !ModLoader.HasMod("RevengeancePlus"))
				&& (modpath == @"JAtRT\Localization\RevengeancePlus\ru-RU_Mods.RevengeancePlus.hjson"
				|| modpath == @"JAtRT\Localization\HomewardRagnarok\ru-RU_Mods.RevengeancePlus.hjson"))
					continue;

				if (!JARTLocalizationConf.Instance.ShimmerGunLocalization
				&& modpath == @"JAtRT\Localization\ShimmerGun\ru-RU_Mods.ShimmerGun.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SOTSBardHealerLocalization
				&& modpath == @"JAtRT\Localization\SOTSBardHealer\ru-RU_Mods.SOTSBardHealer.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SoulsBossRushLocalization
				&& modpath == @"JAtRT\Localization\SoulsBossRush\ru-RU_Mods.SoulsBossRush.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SteamFixerLocalization
				&& modpath == @"JAtRT\Localization\SteamFixer\ru-RU_Mods.SteamFixer.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ThoriumTagsLocalization
				&& modpath == @"JAtRT\Localization\ThoriumClassTagsConsistency\ru-RU_Mods.ThoriumClassTagsConsistency.hjson")
					continue;

				if (Skip(JARTLocalizationConf.Instance.ThrowerUnificationFix, "ThrowerUnification",
				modpath, @"JAtRT\Localization\ThrowerUnification\ru-RU.hjson"))
					continue;

				if (!JARTLocalizationConf.Instance.WingSlotLocalization
				&& modpath == @"JAtRT\Localization\WingSlot\ru-RU_Mods.WingSlot.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.YouBossLocalization
				&& modpath == @"JAtRT\Localization\YouBoss\ru-RU_Mods.YouBoss.hjson")
					continue;

				// v1.3.0.0

				if (!JARTLocalizationConf.Instance.ArmorAndAccessoryPrefixesLocalization
				&& modpath == @"JAtRT\Localization\ArmorAndAccessoryPrefixes\ru-RU_Mods.ArmorAndAccessoryPrefixes.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ArmorBuffsLocalization
				&& modpath == @"JAtRT\Localization\ArmorBuffs\ru-RU_Mods.ArmorBuffs.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ColouredModsRelicsLocalization
				&& modpath == @"JAtRT\Localization\ColouredModsRelics\ru-RU_Mods.ColouredModsRelics.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.CompactModsFix
				&& modpath == @"JAtRT\Localization\CompactMods\ru-RU_Mods.CompactMods.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ConsolariaLegecyItemsLocalization
				&& modpath == @"JAtRT\Localization\ConsolariaLegecyItems\ru-RU_Mods.ConsolariaLegecyItems.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.DraedonExpansionFix
				&& modpath == @"JAtRT\Localization\DraedonExpansion\ru-RU_Mods.DraedonExpansion.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.ExtraWorldSizesLocalization
				&& modpath == @"JAtRT\Localization\ExtraWorldSizes\ru-RU_Mods.ExtraWorldSizes.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.FargosAltMusicModLocalization
				&& modpath == @"JAtRT\Localization\FargoAltMusicMod\ru-RU_Mods.FargoAltMusicMod.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.GauntletsLocalization
				&& modpath == @"JAtRT\Localization\Gauntlets\ru-RU_Mods.Gauntlets.hjson")
					continue;

				if (Skip(JARTLocalizationConf.Instance.MasomodeEXLocalization, "MasomodeEX",
				modpath, @"JAtRT\Localization\MasomodeEX\ru-RU.hjson"))
					continue;

				if (!JARTLocalizationConf.Instance.ModlistIncompatibilitySolverLocalization
				&& modpath == @"JAtRT\Localization\ModlistIncompatibilitySolver\ru-RU_Mods.ModlistIncompatibilitySolver.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MunchiesLocalization
				&& modpath == @"JAtRT\Localization\Munchies\ru-RU_Mods.Munchies.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MunchiesCalamityAddonLocalization
				&& modpath == @"JAtRT\Localization\Munchies_CalamityAddon\ru-RU_Mods.Munchies_CalamityAddon.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.PetrifiedVoodooDollLocalization
				&& modpath == @"JAtRT\Localization\PetrifiedVoodooDoll\ru-RU_Mods.PetrifiedVoodooDoll.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.PolyphemalusLocalization
				&& modpath == @"JAtRT\Localization\Polyphemalus\ru-RU_Mods.Polyphemalus.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.PrimeReworkLocalization
				&& modpath == @"JAtRT\Localization\PrimeRework\ru-RU_Mods.PrimeRework.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.TalismanofFriendshipLocalization
				&& modpath == @"JAtRT\Localization\TalismanofFriendship\ru-RU_Mods.TalismanofFriendship.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.TurtleBoulderLocalization
				&& modpath == @"JAtRT\Localization\TurtleBoulder\ru-RU_Mods.TurtleBoulder.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.WADTULocalization
				&& modpath == @"JAtRT\Localization\WhatAmmoDoesThisUse\ru-RU_Mods.WhatAmmoDoesThisUse.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.WoTELocalization
				&& modpath == @"JAtRT\Localization\WoTE\ru-RU_Mods.WoTE.hjson")
					continue;

				// v1.3.1.0

				if (!JARTLocalizationConf.Instance.CalamityShoesLocalization
				&& modpath == @"JAtRT\Localization\CalamityShoes\ru-RU_Mods.CalamityShoes.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.RobesOfCalamityLocalization
				&& modpath == @"JAtRT\Localization\RobesOfCalamity\ru-RU_Mods.RobesOfCalamity.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.UnCalamityMusicLocalization
				&& modpath == @"JAtRT\Localization\UnCalamityModMusic\ru-RU_Mods.UnCalamityModMusic.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MusicBoxSlotLocalization
				&& modpath == @"JAtRT\Localization\MusicBoxSlotNew\ru-RU_Mods.MusicBoxSlotNew.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.MunchiesHomewardLocalization
				&& modpath == @"JAtRT\Localization\MunchiesHomeward\ru-RU_Mods.MunchiesHomeward.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.InfernalEclipseBalanceLocalization
				&& modpath == @"JAtRT\Localization\InfernalEclipseBalance\ru-RU_Mods.InfernalEclipseBalance.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SolynWeaponLocalization
				&& modpath == @"JAtRT\Localization\SolynWeapon\ru-RU_Mods.SolynWeapon.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.CosmicElementalPetLocalization
				&& modpath == @"JAtRT\Localization\CosmicElementalPet\ru-RU_Mods.CosmicElementalPet.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.HollowKnightLocalization
				&& modpath == @"JAtRT\Localization\MudgysHollowKnightMod\ru-RU_Mods.MudgysHollowKnightMod.hjson")
					continue;

				// v1.3.2.0

				if (!JARTLocalizationConf.Instance.ShroomariaLocalization
				&& modpath == @"JAtRT\Localization\Shroomaria\ru-RU_Mods.Shroomaria.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.InfernumMasterPatchLocalization
				&& modpath == @"JAtRT\Localization\InfernumMasterPatch\ru-RU_Mods.InfernumMasterPatch.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.CalamitySimpleWhipAddonLocalization
				&& modpath == @"JAtRT\Localization\CalamitySimpleWhipAddon\ru-RU.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.SWBADTsLocalization
				&& modpath == @"JAtRT\Localization\SWBADTs\ru-RU_Mods.SWBADTs.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.FlinxHatFix
				&& modpath == @"JAtRT\Localization\FlinxHat\ru-RU_Mods.FlinxHat.hjson")
					continue;

				if (!JARTLocalizationConf.Instance.InfernumLegendAndMasFix
				&& modpath == @"JAtRT\Localization\InfernumLegendAndMas\ru-RU.hjson")
					continue;

				// 1.4.0.0

				if (Skip(JARTLocalizationConf.Instance.MunchiesAuricSoulsAddonLocalization, "MunchiesAuricSoulsAddon",
				modpath, @"JAtRT\Localization\MunchiesAuricSoulsAddon\ru-RU_Mods.MunchiesAuricSoulsAddon.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.FutureBossesLocalization, "FutureBosses",
				modpath, @"JAtRT\Localization\FutureBosses\ru-RU_Mods.FutureBosses.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.ExtraBeginningsLocalization, "ExtraBeginnings",
				modpath, @"JAtRT\Localization\ExtraBeginnings\ru-RU_Mods.ExtraBeginnings.hjson"))
					continue;

				// 1.4.1.0

				if (Skip(JARTLocalizationConf.Instance.HomewardWorldGenFixLocalization, "HomewardWorldGenFix",
				modpath, @"JAtRT\Localization\HomewardWorldGenFix\ru-RU_Mods.HomewardWorldGenFix.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.EverwareLocalization, "Everware",
				modpath, @"JAtRT\Localization\Everware\ru-RU_Mods.Everware.hjson"))
					continue;

				// 1.5.0.0

				if (Skip(JARTLocalizationConf.Instance.PinnacleReforgesLocalization, "PinnacleReforges",
				modpath, @"JAtRT\Localization\PinnacleReforges\ru-RU_Mods.PinnacleReforges.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.NightshadeVanityCursorsLocalization, "NightshadeVanityCursors",
				modpath, @"JAtRT\Localization\NightshadeVanityCursors\ru-RU_Mods.NightshadeVanityCursors.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.CelestialShieldLocalization, "CelestialShield",
				modpath, @"JAtRT\Localization\CelestialShield\ru-RU_Mods.CelestialShield.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.MoveSpeedFixLocalization, "MoveSpeedFix",
				modpath, @"JAtRT\Localization\MoveSpeedFix\ru-RU_Mods.MoveSpeedFix.hjson"))
					continue;

				if (Skip(JARTLocalizationConf.Instance.InfernumFablesLocalization, "InfernumFables",
				modpath, @"JAtRT\Localization\InfernumFables\ru-RU_Mods.InfernumFables.hjson"))
					continue;

				using Stream stream = tModFile.GetStream(translationFile);
				using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, true);

				string translationFileContents = streamReader.ReadToEnd();

				HashSet<(string Mod, string fileName)> changedFiles = typeof(LocalizationLoader).GetMemberValue<HashSet<(string Mod, string fileName)>>("changedFiles");

				if (!string.IsNullOrWhiteSpace(sourceFolder) && changedFiles.Select(x => Path.Join(x.Mod, x.fileName).Replace('/', '\\')).Contains(modpath))
				{
					string path = Path.Combine(sourceFolder, translationFile.Name);

					if (File.Exists(path))
					{
						try
						{
							translationFileContents = File.ReadAllText(path);
						}
						catch (Exception)
						{
							// ignored
						}
					}
				}

				string jsonString;
				try
				{
					jsonString = HjsonValue.Parse(translationFileContents).ToString();
				}
				catch (Exception e)
				{
					string additionalContext = "";
					if (e is ArgumentException && Regex.Match(e.Message, "At line (\\d+),") is { Success: true } match && int.TryParse(match.Groups[1].Value, out int line))
					{
						string[] lines = translationFileContents.Replace("\r", "").Replace("\t", "    ").Split('\n');
						int start = Math.Max(0, line - 4);
						int end = Math.Min(lines.Length, line + 3);
						StringBuilder linesOutput = new StringBuilder();
						for (int i = start; i < end; i++)
						{
							if (line - 1 == i)
								linesOutput.Append($"\n{i + 1}[c/ff0000:>" + lines[i] + "]");
							else
								linesOutput.Append($"\n{i + 1}:" + lines[i]);
						}
						additionalContext = "\nContext:" + linesOutput;
					}
					throw new Exception($"The localization file \"{translationFile.Name}\" is malformed and failed to load:{additionalContext} ", e);
				}

				JObject jsonObject = JObject.Parse(jsonString);

				foreach (JToken t in jsonObject.SelectTokens("$..*"))
				{
					if (t.HasValues)
						continue;

					if (t is JObject obj && obj.Count == 0)
						continue;

					string path = "";
					JToken current = t;

					for (JToken parent = t.Parent; parent != null; parent = parent.Parent)
					{
						path = parent switch
						{
							JProperty property => property.Name + (path == string.Empty ? string.Empty : "." + path),
							JArray array => array.IndexOf(current) + (path == string.Empty ? string.Empty : "." + path),
							_ => path
						};
						current = parent;
					}

					path = path.Replace(".$parentVal", "");
					if (!string.IsNullOrWhiteSpace(prefix))
						path = prefix + "." + path;

					flattened.Add((path, t.ToString()));

					if (tModFile.Name == nameof(JAtRT))
						_customKeys.Add(path);
				}
			}

			if (tModFile.Name != nameof(JAtRT))
				flattened.RemoveAll(pair => _customKeys.Contains(pair.Item1));

			return flattened;
		}
		catch (Exception e)
		{
			e.Data["mod"] = tModFile.Name;
			throw;
		}
	}
}
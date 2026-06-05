/*using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JAtRT.Common;
using JAtRT.Common.Utilities;
using JAtRT.Core.Config;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

public partial class CBuff : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => TranslationHelper.IsRussianLanguage;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (!ModLoader.HasMod("CalamityMod"))
            return;

        foreach (var tooltip in tooltips)
        {
            // Vanilla
            tooltip.Text = tooltip.Text.Replace("«Кровотечение»", "[cbuff:Bleeding]");
            tooltip.Text = tooltip.Text.Replace("«Чернота»", "[cbuff:Blackout]");
            tooltip.Text = tooltip.Text.Replace("«Ихор»", "[cbuff:Ichor]");
            tooltip.Text = tooltip.Text.Replace("«В огне!»", "[cbuff:OnFire]");
            tooltip.Text = tooltip.Text.Replace("«Проклятое инферно»", "[cbuff:CursedInferno]");
            tooltip.Text = tooltip.Text.Replace("«Охотник»", "[cbuff:Hunter]");
            tooltip.Text = tooltip.Text.Replace("«Расколотая броня»", "[cbuff:BrokenArmor]");
            tooltip.Text = tooltip.Text.Replace("«Строитель»", "[cbuff:Builder]");
            tooltip.Text = tooltip.Text.Replace("«Горение»", "[cbuff:Burning]");
            tooltip.Text = tooltip.Text.Replace("«Хаотичное состояние»", "[cbuff:ChaosState]");
            tooltip.Text = tooltip.Text.Replace("«Окоченелость»", "[cbuff:Chilled]");
            tooltip.Text = tooltip.Text.Replace("«Ясновидение»", "[cbuff:Clairvoyance]");
            tooltip.Text = tooltip.Text.Replace("«Замешательство»", "[cbuff:Confused]");
            tooltip.Text = tooltip.Text.Replace("«Проклятие»", "[cbuff:Cursed]");
            tooltip.Text = tooltip.Text.Replace("«Предчувствие»", "[cbuff:Dangersense]");
            tooltip.Text = tooltip.Text.Replace("«Мрак»", "[cbuff:Darkness]");
            tooltip.Text = tooltip.Text.Replace("«Ошеломление»", "[cbuff:Dazed]");
            tooltip.Text = tooltip.Text.Replace("«Благословение дриады»", "[cbuff:DryadsWard]");
            tooltip.Text = tooltip.Text.Replace("«Электризация»", "[cbuff:Electrified]");
            tooltip.Text = tooltip.Text.Replace("«Выносливость»", "[cbuff:Endurance]");
            tooltip.Text = tooltip.Text.Replace("«Рыболовство»", "[cbuff:Fishing]");
            tooltip.Text = tooltip.Text.Replace("«Обжигающий холод»", "[cbuff:Frostburn]");
            tooltip.Text = tooltip.Text.Replace("«Обморожение»", "[cbuff:Frostburn2]");
            tooltip.Text = tooltip.Text.Replace("«Замёрзший»", "[cbuff:Frozen]");
            tooltip.Text = tooltip.Text.Replace("«Мёд»", "[cbuff:Honey]");
            tooltip.Text = tooltip.Text.Replace("«Инферно»", "[cbuff:Inferno]");
            tooltip.Text = tooltip.Text.Replace("«Железная кожа»", "[cbuff:Ironskin]");
            tooltip.Text = tooltip.Text.Replace("«Удачливый»", "[cbuff:Lucky]");
            tooltip.Text = tooltip.Text.Replace("«Истощение маны»", "[cbuff:ManaSickness]");
            tooltip.Text = tooltip.Text.Replace("«Адский огонь»", "[cbuff:OnFire3]");
            tooltip.Text = tooltip.Text.Replace("«Паника!»", "[cbuff:Panic]");
            tooltip.Text = tooltip.Text.Replace("«Решающий удар»", "[cbuff:ParryDamageBuff]");
            tooltip.Text = tooltip.Text.Replace("«Отравлен»", "[cbuff:Poisoned]");
            tooltip.Text = tooltip.Text.Replace("«Послезельевая болезнь»", "[cbuff:PotionSickness]");
            tooltip.Text = tooltip.Text.Replace("«Звериный укус»", "[cbuff:Rabies]");
            tooltip.Text = tooltip.Text.Replace("«Ярость»", "[cbuff:Rage]");
            tooltip.Text = tooltip.Text.Replace("«Быстрое исцеление»", "[cbuff:RapidHealing]");
            tooltip.Text = tooltip.Text.Replace("«Регенерация»", "[cbuff:Regeneration]");
            tooltip.Text = tooltip.Text.Replace("«Теневое пламя»", "[cbuff:ShadowFlame]");
            tooltip.Text = tooltip.Text.Replace("«Заточенный»", "[cbuff:Sharpened]");
            tooltip.Text = tooltip.Text.Replace("«Мерцающий»", "[cbuff:Shimmer]");
            tooltip.Text = tooltip.Text.Replace("«Свечение»", "[cbuff:Shine]");
            tooltip.Text = tooltip.Text.Replace("«Слизь»", "[cbuff:Slimed]");
            tooltip.Text = tooltip.Text.Replace("«Медлительность»", "[cbuff:Slow]");
            tooltip.Text = tooltip.Text.Replace("«Спелеолог»", "[cbuff:Spelunker]");
            tooltip.Text = tooltip.Text.Replace("«Иссушение жизни»", "[cbuff:SoulDrain]");
            tooltip.Text = tooltip.Text.Replace("«Сонар»", "[cbuff:Sonar]");
            tooltip.Text = tooltip.Text.Replace("«Изнеможение»", "[cbuff:Starving]");
            tooltip.Text = tooltip.Text.Replace("«Окаменелый»", "[cbuff:Stoned]");
            tooltip.Text = tooltip.Text.Replace("«Удушье»", "[cbuff:Suffocation]");
            tooltip.Text = tooltip.Text.Replace("«Счастье!»", "[cbuff:Sunflower]");
            tooltip.Text = tooltip.Text.Replace("«Стремительность»", "[cbuff:Swiftness]");
            tooltip.Text = tooltip.Text.Replace("«Шипы»", "[cbuff:Thorns]");
            tooltip.Text = tooltip.Text.Replace("«Подвыпивший»", "[cbuff:Tipsy]");
            tooltip.Text = tooltip.Text.Replace("«Титан»", "[cbuff:Titan]");
            tooltip.Text = tooltip.Text.Replace("«Титановый барьер»", "[cbuff:TitaniumStorm]");
            tooltip.Text = tooltip.Text.Replace("«Кислотный яд»", "[cbuff:Venom]");
            tooltip.Text = tooltip.Text.Replace("«Искажённый»", "[cbuff:VortexDebuff]");
            tooltip.Text = tooltip.Text.Replace("«Тепло»", "[cbuff:Warmth]");
            tooltip.Text = tooltip.Text.Replace("«Стратег»", "[cbuff:WarTable]");
            tooltip.Text = tooltip.Text.Replace("«Водяная свеча»", "[cbuff:WaterCandle]");
            tooltip.Text = tooltip.Text.Replace("«Хождение по воде»", "[cbuff:WaterWalking]");
            tooltip.Text = tooltip.Text.Replace("«Слабость»", "[cbuff:Weak]");
            tooltip.Text = tooltip.Text.Replace("«В паутине»", "[cbuff:Webbed]");
            tooltip.Text = tooltip.Text.Replace("«Перекус»", "[cbuff:WellFed]");
            tooltip.Text = tooltip.Text.Replace("«Сытная трапеза»", "[cbuff:WellFed2]");
            tooltip.Text = tooltip.Text.Replace("«Набитый желудок»", "[cbuff:WellFed3]");
            tooltip.Text = tooltip.Text.Replace("«Обмокший»", "[cbuff:Wet]");
            tooltip.Text = tooltip.Text.Replace("«Сгнившая броня»", "[cbuff:WitheredArmor]");
            tooltip.Text = tooltip.Text.Replace("«Сгнившее оружие»", "[cbuff:WitheredWeapon]");
            tooltip.Text = tooltip.Text.Replace("«Гнев»", "[cbuff:Wrath]");
            tooltip.Text = tooltip.Text.Replace("«Призыв»", "[cbuff:Summoning]");
            tooltip.Text = tooltip.Text.Replace("«Сахарная передозировка»", "[cbuff:SugarRush]");
            tooltip.Text = tooltip.Text.Replace("«Вонючка»", "[cbuff:Stinky]");
            tooltip.Text = tooltip.Text.Replace("«Свеча спокойствия»", "[cbuff:PeaceCandle]");
            tooltip.Text = tooltip.Text.Replace("«Звезда в банке»", "[cbuff:StarInBottle]");
            tooltip.Text = tooltip.Text.Replace("«Поедание клетками»", "[cbuff:StardustMinionBleed]");
            tooltip.Text = tooltip.Text.Replace("«Безмолвие»", "[cbuff:Silenced]");
            tooltip.Text = tooltip.Text.Replace("«Оклеен»", "[cbuff:OgreSpit]");
            tooltip.Text = tooltip.Text.Replace("«Ослепление»", "[cbuff:Obstructed]");
            tooltip.Text = tooltip.Text.Replace("«Обсидиановая кожа»", "[cbuff:ObsidianSkin]");
            tooltip.Text = tooltip.Text.Replace("«Творческий шок»", "[cbuff:NoBuilding]");
            tooltip.Text = tooltip.Text.Replace("«Полуночник»", "[cbuff:NightOwl]");
            tooltip.Text = tooltip.Text.Replace("«Недоедание»", "[cbuff:NeutralHunger]");
            tooltip.Text = tooltip.Text.Replace("«Лунный укус»", "[cbuff:MoonLeech]");
            tooltip.Text = tooltip.Text.Replace("«Знамя»", "[cbuff:MonsterBanner]");
            tooltip.Text = tooltip.Text.Replace("«Добыча»", "[cbuff:Mining]");
            tooltip.Text = tooltip.Text.Replace("«Восстановление маны»", "[cbuff:ManaRegeneration]");
            tooltip.Text = tooltip.Text.Replace("«Магическая сила»", "[cbuff:MagicPower]");
            tooltip.Text = tooltip.Text.Replace("«Влюблённость»", "[cbuff:Lovestruck]");
            tooltip.Text = tooltip.Text.Replace("«Жизненная сила»", "[cbuff:Lifeforce]");
            tooltip.Text = tooltip.Text.Replace("«Кристальный лист»", "[cbuff:LeafCrystal]");
            tooltip.Text = tooltip.Text.Replace("«Железная кожа»", "[cbuff:Ironskin]");
            tooltip.Text = tooltip.Text.Replace("«Невидимость»", "[cbuff:Invisibility]");
            tooltip.Text = tooltip.Text.Replace("«Ледяная преграда»", "[cbuff:IceBarrier]");
            tooltip.Text = tooltip.Text.Replace("«Ужаснувшийся»", "[cbuff:Horrified]");
            tooltip.Text = tooltip.Text.Replace("«Сердечное притяжение»", "[cbuff:Heartreach]");
            tooltip.Text = tooltip.Text.Replace("«Гравитация»", "[cbuff:Gravitation]");
            tooltip.Text = tooltip.Text.Replace("«Жабры»", "[cbuff:Gills]");
            tooltip.Text = tooltip.Text.Replace("«Плавучесть»", "[cbuff:Flipper]");
            tooltip.Text = tooltip.Text.Replace("«Лёгкость»", "[cbuff:Featherfall]");
            tooltip.Text = tooltip.Text.Replace("«Проклятие дриады»", "[cbuff:DryadsWardDebuff]");
            tooltip.Text = tooltip.Text.Replace("«Солнечный ожог»", "[cbuff:Daybreak]");
            tooltip.Text = tooltip.Text.Replace("«Ловец ящиков»", "[cbuff:Crate]");
            tooltip.Text = tooltip.Text.Replace("«Защита Бастет»", "[cbuff:CatBast]");
            tooltip.Text = tooltip.Text.Replace("«Уютный очаг»", "[cbuff:Campfire]");
            tooltip.Text = tooltip.Text.Replace("«Умиротворение»", "[cbuff:Calm]");
            tooltip.Text = tooltip.Text.Replace("«Проткнут»", "[cbuff:BoneJavelin]");
            tooltip.Text = tooltip.Text.Replace("«Биомное зрение»", "[cbuff:BiomeSight]");
            tooltip.Text = tooltip.Text.Replace("«Колдовство»", "[cbuff:Bewitched]");
            tooltip.Text = tooltip.Text.Replace("«Проклятие Бэтси»", "[cbuff:BetsysCurse]");
            tooltip.Text = tooltip.Text.Replace("«Боевой азарт»", "[cbuff:Battle]");
            tooltip.Text = tooltip.Text.Replace("«Паническая атака баллисты!»", "[cbuff:BallistaPanic]");
            tooltip.Text = tooltip.Text.Replace("«Ящик с боеприпасами»", "[cbuff:AmmoBox]");
            tooltip.Text = tooltip.Text.Replace("«Экономия боеприпасов»", "[cbuff:AmmoReservation]");
            tooltip.Text = tooltip.Text.Replace("«Бушующий ветер»", "[cbuff:WindPushed]");
            if (item.ModItem?.Mod.Name != "FargowiltasSouls")
            {
                tooltip.Text = tooltip.Text.Replace("«Промасленный»", "[cbuff:Oiled]");
                tooltip.Text = tooltip.Text.Replace("«Мидас»", "[cbuff:Midas]");
            }

            // Fargo's
            if (ModInstances.FargowiltasSouls != null)
            {
                if (item.ModItem?.Mod.Name == "FargowiltasSouls")
                {
                    tooltip.Text = tooltip.Text.Replace("«Обмокший лавой»", "[cbuff:FargowiltasSouls/ObsidianLavaWetBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Титановый щит»", "[cbuff:FargowiltasSouls/TitaniumDRBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Мерзкий клык»", "[cbuff:FargowiltasSouls/AbomFangBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Мерзкое присутствие»", "[cbuff:FargowiltasSouls/AbomPresenceBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Схвачен»", "[cbuff:FargowiltasSouls/GrabbedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Клык Мутанта»", "[cbuff:FargowiltasSouls/MutantFangBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Присутствие Мутанта»", "[cbuff:FargowiltasSouls/MutantPresenceBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Адский огонь»", "[cbuff:FargowiltasSouls/HellFireBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Антикоагуляция»", "[cbuff:FargowiltasSouls/AnticoagulationBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Асоциальность»", "[cbuff:FargowiltasSouls/AntisocialBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Атрофия»", "[cbuff:FargowiltasSouls/AtrophiedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Разъярённый»", "[cbuff:FargowiltasSouls/BerserkedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Кровопийца»", "[cbuff:FargowiltasSouls/BloodDrinkerBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Жажда крови»", "[cbuff:FargowiltasSouls/BloodthirstyBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Мозговой перелом»", "[cbuff:FargowiltasSouls/BrainOfConfusionBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Подрезанные крылья»", "[cbuff:FargowiltasSouls/ClippedWingsBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Искалеченный»", "[cbuff:FargowiltasSouls/CrippledBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Проклятие Луны»", "[cbuff:FargowiltasSouls/CurseoftheMoonBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Беззащитный»", "[cbuff:FargowiltasSouls/DefenselessBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Пламя Космоса»", "[cbuff:FargowiltasSouls/FlamesoftheUniverseBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Перевёрнутый»", "[cbuff:FargowiltasSouls/FlippedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Подсвеченный»", "[cbuff:FargowiltasSouls/HallowIlluminatedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Запал»", "[cbuff:FargowiltasSouls/FusedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Виновный»", "[cbuff:FargowiltasSouls/GuiltyBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Заколдован»", "[cbuff:FargowiltasSouls/HexedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Святая цена»", "[cbuff:FargowiltasSouls/HolyPriceBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Гипотермия»", "[cbuff:FargowiltasSouls/HypothermiaBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Заражённый»", "[cbuff:FargowiltasSouls/InfestedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Яд плюща»", "[cbuff:FargowiltasSouls/IvyVenomBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Заклиненный»", "[cbuff:FargowiltasSouls/JammedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Летаргия»", "[cbuff:FargowiltasSouls/LethargicBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Громоотвод»", "[cbuff:FargowiltasSouls/LightningRodBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Благословение яхщеров»", "[cbuff:FargowiltasSouls/LihzahrdBlessingBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Проклятие яхщеров»", "[cbuff:FargowiltasSouls/LihzahrdCurseBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Живая пустошь»", "[cbuff:FargowiltasSouls/LivingWastelandBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Дырявые карманы»", "[cbuff:FargowiltasSouls/LoosePocketsBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Влюблённость»", "[cbuff:FargowiltasSouls/LovestruckBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Низина»", "[cbuff:FargowiltasSouls/LowGroundBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Клеймённый на смерть»", "[cbuff:FargowiltasSouls/MarkedforDeathBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Укус Мутанта»", "[cbuff:FargowiltasSouls/MutantNibbleBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Наноинъекция»", "[cbuff:FargowiltasSouls/NanoInjectionBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Нейротоксин»", "[cbuff:FargowiltasSouls/NeurotoxinBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Проклятие нейтрализации»", "[cbuff:FargowiltasSouls/NullificationCurseBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Океаническое истязание»", "[cbuff:FargowiltasSouls/OceanicMaulBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Океаническая печать»", "[cbuff:FargowiltasSouls/OceanicSealBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Острый взгляд»", "[cbuff:FargowiltasSouls/PungentGazeBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Вычищенный»", "[cbuff:FargowiltasSouls/PurgedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Очищенный»", "[cbuff:FargowiltasSouls/PurifiedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Освежённый»", "[cbuff:FargowiltasSouls/RefreshedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Обратный поток маны»", "[cbuff:FargowiltasSouls/ReverseManaFlowBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Гниение»", "[cbuff:FargowiltasSouls/RottingBuff]");
                    tooltip.Text = tooltip.Text.Replace("«На скорую руку»", "[cbuff:FargowiltasSouls/RushJobBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Вечность»", "[cbuff:FargowiltasSouls/SadismBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Кара»", "[cbuff:FargowiltasSouls/SmiteBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Игрушка-пищалка»", "[cbuff:FargowiltasSouls/SqueakyToyBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Оглушённый»", "[cbuff:FargowiltasSouls/StunnedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Роение»", "[cbuff:FargowiltasSouls/SwarmingBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Перезарядка кражи»", "[cbuff:FargowiltasSouls/ThiefCDBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Невезение»", "[cbuff:FargowiltasSouls/UnluckyBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Нестабильность»", "[cbuff:FargowiltasSouls/UnstableBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Лунный культист»", "[cbuff:FargowiltasSouls/LunarCultistBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Сила Мутанта»", "[cbuff:FargowiltasSouls/MutantPowerBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Перерождение Мутанта»", "[cbuff:FargowiltasSouls/MutantRebirthBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Сломанный панцирь»", "[cbuff:FargowiltasSouls/BrokenShellBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Багряное лечение»", "[cbuff:FargowiltasSouls/CrimsonRegenBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Первый удар»", "[cbuff:FargowiltasSouls/FirstStrikeBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Возрождённый»", "[cbuff:FargowiltasSouls/FossilReviveCDBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Золотой стазис»", "[cbuff:FargowiltasSouls/GoldenStasisBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Кровоток охотницы»", "[cbuff:FargowiltasSouls/HuntressBleedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Свинцовый яд»", "[cbuff:FargowiltasSouls/LeadPoisonBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Раскалённое усиление»", "[cbuff:FargowiltasSouls/MoltenAmplifyBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Орихалковый яд»", "[cbuff:FargowiltasSouls/OriPoisonBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Медитация»", "[cbuff:FargowiltasSouls/MonkBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Солнечная вспышка»", "[cbuff:FargowiltasSouls/SolarFlareBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Кровавый гейзер»", "[cbuff:FargowiltasSouls/SuperBleedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Иссушающий»", "[cbuff:FargowiltasSouls/CorruptingBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Заморозка времени»", "[cbuff:FargowiltasSouls/TimeFrozenBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Сверхзаряжен»", "[cbuff:FargowiltasSouls/SuperchargedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Лукавая улыбка»", "[cbuff:FargowiltasSouls/MoonBowBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Проклятые чары»", "[cbuff:FargowiltasSouls/WretchedHexBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Иссушённый»", "[cbuff:FargowiltasSouls/WitheredBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Иссушённый (Сила)»", "[cbuff:FargowiltasSouls/WitheredWizardBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Грибная сила»", "[cbuff:FargowiltasSouls/MushroomPowerBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Солнечное усиление»", "[cbuff:FargowiltasSouls/SolarBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Амброзия»", "[cbuff:FargowiltasSouls/AmbrosiaBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Кровотечение»", "[cbuff:FargowiltasSouls/BleedingOut]");
                    tooltip.Text = tooltip.Text.Replace("«Призрачная ярость»", "[cbuff:FargowiltasSouls/MutantDesperationBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Гладиаторская сила»", "[cbuff:FargowiltasSouls/GladiatorBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Сублимация»", "[cbuff:FargowiltasSouls/SublimationBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Магическое проклятие»", "[cbuff:FargowiltasSouls/MagicalCurseBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Лунный клык»", "[cbuff:FargowiltasSouls/MoonFangBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Земной яд»", "[cbuff:FargowiltasSouls/EarthPoison]");
                    tooltip.Text = tooltip.Text.Replace("«Увядшая сила»", "[cbuff:FargowiltasSouls/WitheredForceBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Древесная сила»", "[cbuff:FargowiltasSouls/TimberBleedBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Промасленный»", "[cbuff:FargowiltasSouls/OiledBuff]");
                    tooltip.Text = tooltip.Text.Replace("«Мидас»", "[cbuff:FargowiltasSouls/MidasBuff]");
                }
            }
            
            // Shroomaria
            if (ModInstances.Shroomaria != null)
            {
                tooltip.Text = tooltip.Text.Replace("«Грибной недуг»", "[cbuff:Shroomaria/FungalFever]");
            }
        }
    }
}
*/
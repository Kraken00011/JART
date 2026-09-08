/*using System;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Localization;
using JAtRT.Core.Config;

public class BossNameDisplaySystem : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModLoader.HasMod("BossNameDisplay") && Language.ActiveCulture.Name == "ru-RU" && JARTLocalizationConf.Instance.BossNameDisplayLocalization;
    }

    public override void PostSetupContent()
    {
        Asset<SpriteFont> cyrillicFont = Mod.Assets.Request<SpriteFont>(
            "Assets/Fonts/BossTitleCyrillic",
            AssetRequestMode.ImmediateLoad
        );

        Type bossSystem = ModLoader.GetMod("BossNameDisplay").GetType().Assembly.GetType("BossTitleSystem");

        if (bossSystem is null)
        {
            Mod.Logger.Warn("[BossNameDisplaySystem] Не удалось найти тип BossTitleSystem.");
            return;
        }

        FieldInfo field = bossSystem.GetField("BossTitleFont", 
            BindingFlags.Public | BindingFlags.Static);

        if (field is null)
        {
            Mod.Logger.Warn("[BossNameDisplaySystem] Не удалось найти поле BossTitleFont.");
            return;
        }

        field.SetValue(null, cyrillicFont);
    }
}
*/
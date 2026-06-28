using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

public partial class CombatTextPatch : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU";
    public override void Load()
    {
        On_CombatText.NewText_Rectangle_Color_string_bool_bool += ReplaceText;
    }

    public override void Unload()
    {
        On_CombatText.NewText_Rectangle_Color_string_bool_bool -= ReplaceText;
    }

    private int ReplaceText(On_CombatText.orig_NewText_Rectangle_Color_string_bool_bool orig, Rectangle location, Color color, string text, bool dramatic, bool dot)
    {
        text = text switch
        {
            // Prime Rework
            "Laser Mode" => "Модуль лазера",
            "Cannon Mode" => "Модуль пушки",
            "Saw Mode" => "Модуль пилы",
            "Hook Mode" => "Модуль крюка",
            "ENRAGE IS NEAR!" => "БОСС СКОРО ВОЙДЁТ В ЯРОСТЬ!",
            // Infernal Eclipse API
            "REALITY COMPROMISED" => "РЕАЛЬНОСТЬ РУШИТСЯ",
            "THE CLOWN HAS BEEN ENGAGED." => "КЛОУН ВЫШЕЛ ПОИГРАТЬ.",
            "VENGEANCE." => "МЕСТЬ.",
            "SUFFER." => "СТРАДАЙ.",
            _ => text
        };

        return orig(location, color, text, dramatic, dot);
    }
}
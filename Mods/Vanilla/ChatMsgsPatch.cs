using JAtRT.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Chat;
using Terraria.ModLoader;

public class ChatMessagesPatch : ILoadable
{
    public bool IsLoadingEnabled(Mod mod) => TranslationHelper.IsRussianLanguage;

    public void Load(Mod mod)
    {
        On_RemadeChatMonitor.AddNewMessage += On_RemadeChatMonitorOnAddNewMessage;
    }

    public void Unload()
    {
        On_RemadeChatMonitor.AddNewMessage -= On_RemadeChatMonitorOnAddNewMessage;
    }
    
    private void On_RemadeChatMonitorOnAddNewMessage(On_RemadeChatMonitor.orig_AddNewMessage orig, RemadeChatMonitor self, string text, Color color, int widthlimitinpixels)
    {
        // Infernum
        if (text.Contains("Forbidden Archive location moved from"))
        {
            text = text.Replace("Forbidden Archive location moved from", "Местоположение запретных архивов смещено с координат");
            text = text.Replace("to", "на координаты");
        }

        if (text.Contains("Forbidden Archive location reverted to"))
        {
            text = text.Replace("Forbidden Archive location reverted to", "Местоположение запретных архивов смещено с координат");
            text = text.Replace("from", "обратно на координаты");
        }

        // Fargos Alt Music
        text = text.Replace("Now Playing: ", "Сейчас играет: ");

        text = text switch
        {
            // Calamity Zenith
            "你已获得天顶印记" => "Зенит пробудился!",
            // Dragon Lens
            "Smart cursor is disabled with omnipotent building" => "Умный курсор недоступен во время использования «Безграничного строительства»",
            // Boss Cursor
            "Boss Cursor enabled" => "Боссовый курсор активирован",
            "Boss Cursor disabled" => "Боссовый курсор деактивирован",
            // Blue Moon
            "The Blue Moon is rising..." => "Восходит Голубая луна..." ,
            "Восходит Таинственная синяя луна..." => "Восходит Голубая луна...",
            "The Blue Moon has set..." => "Голубая луна заходит за горизонт...",
            "Таинственная синяя луна зашла..." => "Голубая луна заходит за горизонт...",
            "The Cherry Moon is rising..." => "Восходит Вишнёвая луна...",
            "Восходит Цветущая вишнёвая луна..." => "Восходит Вишнёвая луна...",
            "The Cherry Moon has set..." => "Вишнёвая луна заходит за горизонт...",
            "Цветущая вишнёвая луна зашла..." => "Вишнёвая луна заходит за горизонт...",
            "The Mint Moon is rising..." => "Восходит Мятная луна...",
            "Восходит Прохладная мятная луна..." => "Восходит Мятная луна...",
            "The Mint Moon has set..."=> "Мятная луна заходит за горизонт...",
            "Прохладная мятная луна зашла..." => "Мятная луна заходит за горизонт...",
            "The Harvest Moon is rising..." => "Восходит Урожайная луна...",
            "Восходит Праздничная урожайная луна..." => "Восходит Урожайная луна...",
            "The Harvest Moon has set..." => "Урожайная луна заходит за горизонт...",
            "Праздничная урожайная луна зашла..." => "Урожайная луна заходит за горизонт...",
            // Gauntlets
            "Let us know of any bugs you may have encountered or give any feedback. Your input will help us improve and make the mod even better. Thank you!" => "Пожалуйста, дайте нам знать, если вы столкнётесь с любыми ошибками или недочётами. Ваши предложения помогают нам исправлять различные ошибки и делать наш мод лучше в целом. Заранее спасибо!",
            "(Can be disabled in mod config)" => "(Это сообщение можно отключить в конфигурации Whips Accessories)",
            "Let us know of any bugs you may have encountered or give any feedback. Your input will help us improve and make the mod even better. Thank you! (This message can be disabled in mod config settings)" => "Пожалуйста, дайте нам знать, если вы столкнётесь с любыми ошибками или недочётами. Ваши предложения помогают нам исправлять различные ошибки и делать наш мод лучше в целом. Заранее спасибо!\n(Это сообщение можно отключить в конфигурации мода Whips Accessories)",
            // Spirit of Overseer
            "PHOTOSENSITIVITY WARNING: \"Hardmode Spirit Bosses Rework\" mod adds a lot of flashy effects! Especially in boss fights!\nIf you are photosensitive, go to Settings -> Mod Configuration -> Hardmode Spirit Bosses Rework -> Visual Settings and set all the sliders to 0!\nYou can turn off this warning in the config as well if you do not want to keep seeing it!" => "ПРЕДУПРЕЖДЕНИЕ ДЛЯ СВЕТОЧУВСТВИТЕЛЬНЫХ: Spirit Classis Bosses Rework добавляет множество мерцающих и сверкающих эффектов! Особенно во время битв с боссами!\nЕсли вы светочувствительный человек, вы можете зайти в настройки -> Конфигурация модов -> Spirit Classic Bosses Rework -> Клиентская конфигурация и установите все ползунки на 0!\nВы также можете отключить это предупреждение в конфигурации, если вы не хотите его видеть",
            _ => text
        };

        orig.Invoke(self, text, color, widthlimitinpixels);
    }
}
using Terraria.Localization;
using Terraria.ModLoader;

internal class EverwarePrefixes : ModSystem
{
    public override bool IsLoadingEnabled(Mod mod) => Language.ActiveCulture.Name == "ru-RU";
    public override void PostSetupContent()
    {
        ModLoader.TryGetMod("CalamityRuTranslate", out Mod tru);
        ModLoader.TryGetMod("Everware", out Mod Everware);

        if (tru != null && Everware != null)
        {
            tru.Call("AddFeminineItems", Everware, new string[]
            {
                "BookOfBoulders"
            });
        }
    }
}
using JAtRT.Core;
using JAtRT.Core.Config;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace JAtRT;

public class JAtRT : Mod
{
    public static JAtRT Instance;

    public JAtRT()
    {
        Instance = this;
        PreJITFilter = new DisableJIT();
    }

    public override void Unload()
    {
        Instance = null;
        JARTLocalizationConf.Instance = null;
    }
}

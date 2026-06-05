using System;
using Terraria.ModLoader;

namespace JAtRT.Core.MonoMod;

public class MonoModPatcherSystem : ModSystem
{
    public override void OnModLoad()
    {
        var assembly = typeof(JAtRT).Assembly;
        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsSubclassOf(typeof(ILPatcher)) && Activator.CreateInstance(type) is ILPatcher { AutoLoad: true } ilPatcher)
            {
                var method = ilPatcher.ModifiedMethod;
                if (method == null)
                {
                    Logging.PublicLogger.Warn($"[JAtRT] [IL] {type.Name}: метод не найден, пропускаем");
                    continue;
                }
                MonoModHooks.Modify(method, ilPatcher.PatchMethod);
            }

            if (type.IsSubclassOf(typeof(OnPatcher)) && Activator.CreateInstance(type) is OnPatcher { AutoLoad: true } onPatcher)
            {
                var method = onPatcher.ModifiedMethod;
                if (method == null)
                {
                    Logging.PublicLogger.Warn($"[JAtRT] [On] {type.Name}: метод не найден, пропускаем");
                    continue;
                }
                MonoModHooks.Add(method, onPatcher.Delegate);
            }
        }
    }
}
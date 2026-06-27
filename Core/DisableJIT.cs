using System.Reflection;
using Terraria.ModLoader;

namespace JAtRT.Core;

public class DisableJIT : PreJITFilter
{
    public override bool ShouldJIT(MemberInfo member) => false;
}
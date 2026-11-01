using Microsoft.Xna.Framework;
using Terraria.ID;

namespace JAtRT.Core.ChatTags.BuffTags
{
    public class BlueMoonBuffs : BuffInfoModule
    {
        public override string ModName => "BlueMoon";

        public override void Register()
        {
            // баффы
            BuffInfoRegistry.Register("BlueMoon", "LunarEmpowermentBuff", new Color(186, 85, 211));
            BuffInfoRegistry.Register("BlueMoon", "BountifulHarvestBuff", new Color(186, 85, 211));
            BuffInfoRegistry.Register("BlueMoon", "FloralBlessingBuff", new Color(186, 85, 211));
            BuffInfoRegistry.Register("BlueMoon", "MintyFreshnessBuff", new Color(186, 85, 211));
            BuffInfoRegistry.Register("BlueMoon", "MoonsRingBuff", new Color(186, 85, 211));
        }
    }
}
using System.Collections.Generic;

namespace JAtRT.Core.ClassTags
{
    public interface ItemTagsAdder
    {
        bool IsEnabled { get; }
        List<(int ItemType, string TagName)> TaggedItems { get; }
    }

    public interface ItemTagsRemover
    {
        bool IsEnabled { get; }
        List<(int ItemType, string TagName, string ModName)> RemovedItems { get; }
    }
}
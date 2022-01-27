using System.Collections.Generic;

namespace AGCI.AuxClasses
{
    public interface ITreeNode
    {
        ITreeNode GetParent();

        IEnumerable<ITreeNode> GetChildrens();
    }
}
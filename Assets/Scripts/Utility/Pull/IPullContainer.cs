using UnityEngine;

namespace Utility.Pull
{
    public interface IPullContainer
    {
        GameObject GetPrefab();
        Transform GetParent();

        int GetStartCount();
    }
}
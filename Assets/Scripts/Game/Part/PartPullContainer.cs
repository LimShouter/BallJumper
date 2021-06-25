using UnityEngine;
using Utility.Pull;

namespace Game.Part
{
    public class PartPullContainer : MonoBehaviour, IPullContainer
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform root;
        [SerializeField] private int startCount;

        public GameObject GetPrefab()
        {
            return prefab;
        }

        public Transform GetParent()
        {
            return root;
        }

        public int GetStartCount()
        {
            return startCount;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using Utility.Pull;
using Random = System.Random;

namespace Game.Part
{
    public class PartItemView : BasePullObject
    {
        [SerializeField] private List<GameObject> parts;
        [SerializeField] private Material bad;
        [SerializeField] private Material good;

        public void Regenerate()
        {
            foreach (var part in parts) part.SetActive(true);
            GenerateBadParts();
            GenerateHoles();
        }

        public void SetPosition(float yPos)
        {
            transform.localPosition = new Vector3(0, yPos, 0);
        }

        private void GenerateHoles()
        {
            var rnd = new Random();

            for (var i = 1; i < rnd.Next(2, 5); i++)
            {
                var index = rnd.Next(1, 11);
                parts[index].SetActive(false);
                parts[index + 1].SetActive(false);
            }
        }

        private void GenerateBadParts()
        {
            var rnd = new Random((int) Time.realtimeSinceStartup);

            foreach (var part in parts)
            {
                part.GetComponent<Renderer>().material = good;
                part.tag = "Part";
            }

            for (var i = 1; i < rnd.Next(2, 5); i++)
            {
                var index = rnd.Next(1, 12);
                parts[index].tag = "Bad";
                parts[index].GetComponent<Renderer>().material = bad;
            }
        }
    }
}
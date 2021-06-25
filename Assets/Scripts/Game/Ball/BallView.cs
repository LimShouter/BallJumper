using System;
using UnityEngine;
using Utility;

namespace Game.Ball
{
    public class BallView : MonoBehaviour ,IView
    {
        public Animator ballAnimator;


        private void OnTriggerEnter(Collider other)
        {
            OnCollision?.Invoke(other.gameObject);
        }

        public event Action<GameObject> OnCollision;
    }
}
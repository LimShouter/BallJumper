using UnityEngine;
using Utility;

namespace Game.Ball
{
    public class BallPresenter : IPresenter
    {
        private readonly BallView _view;
        private readonly BallData _data;

        public BallPresenter(BallData data, BallView view)
        {
            _data = data;
            _view = view;
        }

        public void Detach()
        {
            _view.OnCollision -= OnCollision;
        }

        public void Attach()
        {
            _view.OnCollision += OnCollision;
        }

        private void OnCollision(GameObject go)
        {
            switch (go.tag)
            {
                case "Part":
                    _data.Jump();
                    break;
                case "Bad":
                    _data.Stop();
                    break;
                default:
                    _data.PartPassed();
                    break;
            }
        }
    }
}
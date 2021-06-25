using System;
using Utility;

namespace Game.Ball
{
    public class BallData : IData
    {
        public event Action OnPartPassed;
        public event Action OnStop;
        public event Action OnJump;


        public void PartPassed()
        {
            OnPartPassed?.Invoke();
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }

        public void Jump()
        {
            OnJump?.Invoke();
        }
    }
}
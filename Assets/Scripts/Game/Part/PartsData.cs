using System;
using Utility;

namespace Game.Part
{
    public class PartsData : IData
    {
        public bool IsStarted;
        public event Action OnStart;
        public event Action OnStop;
        public event Action<float> OnUpdate;

        public void Start()
        {
            OnStart?.Invoke();
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }

        public void Update(float dif)
        {
            OnUpdate?.Invoke(dif);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Game.Part
{
    public class PartsPresenter : IPresenter
    {
        private readonly Queue<PartItemView> _components = new Queue<PartItemView>();
        private readonly Environment _environment;
        private readonly PartsData _data;

        public PartsPresenter(Environment environment, PartsData data)
        {
            _environment = environment;
            _data = data;
        }

        public void Detach()
        {
            _data.OnStart -= Start;
            _data.OnUpdate -= Update;
            _environment.BallData.OnStop -= Stop;
            _environment.BallData.OnPartPassed -= OnPartPassed;
            _environment.BallData.OnJump -= Jump;
        }

        public void Attach()
        {
            _data.OnStart += Start;
            _data.OnUpdate += Update;
            _environment.BallData.OnStop += Stop;
            _environment.BallData.OnPartPassed += OnPartPassed;
            _environment.BallData.OnJump += Jump;
        }

        private void Jump()
        {
            _environment.Player.Speed = -_environment.Player.maxSpeed;
        }

        private void OnPartPassed()
        {
            _environment.ScoreData.AddScore(_environment.ScoreData.Multiplier);
            _environment.ScoreData.Multiplier++;
            _environment.PullCollection.PartPull.Put(_components.Dequeue());
            Create();
        }

        private void Start()
        {
            for (var i = 0; i < 5; i++) Create();
            _data.IsStarted = true;
            _environment.GameScreenData.Show();
            _environment.ScoreData.MaxScore = PlayerPrefs.GetInt("MaxScore");
            _environment.ScoreData.Refresh();
        }

        private void Update(float obj)
        {
            foreach (var component in _components)
            {
                component.transform.Translate(new Vector3(0, _environment.Player.Speed * Time.deltaTime));
                component.transform.Rotate(0, -obj * Time.deltaTime, 0);
            }
        }

        private void Stop()
        {
            var count = _components.Count;
            for (var i = 0; i < count; i++) _environment.PullCollection.PartPull.Put(_components.Dequeue());

            _environment.Player.Speed = 0;
            _data.IsStarted = false;
            _environment.GameScreenData.Hide();
            _environment.RematchData.Show();
            PlayerPrefs.SetInt("MaxScore", _environment.ScoreData.MaxScore);
        }

        private void Create()
        {
            if (_components.Count != 0)
            {
                var component = _environment.PullCollection.PartPull.Get();
                component.Regenerate();
                component.SetPosition(_components.Last().transform.position.y - _environment.Player.distanceBetweenOthers);
                _components.Enqueue(component);
            }
            else
            {
                var component = _environment.PullCollection.PartPull.Get();
                component.Regenerate();
                component.SetPosition(-2);
                _components.Enqueue(component);
            }
        }
    }
}
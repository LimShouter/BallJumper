using System;
using UnityEngine;

namespace UI.GameScreen.ScoreManager
{
    public class ScoreData
    {
        public int MaxScore;

        public int Multiplier = 1;
        public int Score = 0;

        public ScoreData()
        {
            MaxScore = PlayerPrefs.GetInt("MaxScore");
        }

        public event Action<int> OnAddScore;
        public event Action OnRefresh;

        public void AddScore(int score)
        {
            OnAddScore?.Invoke(score);
        }

        public void Refresh()
        {
            OnRefresh?.Invoke();
        }
    }
}
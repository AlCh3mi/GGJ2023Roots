using System;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public class HighScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private void Start()
        {
            var bestTime = Score.BestTime;
            scoreText.text = bestTime <= 0f
                ? "Best Time: ---s"
                : "Best Time: " +bestTime.ToString("0") +"s";
        }
    }
}
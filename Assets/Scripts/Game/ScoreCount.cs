using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Arkanoid.Game
{
    public class ScoreCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        
        public static int Score { get; set; }

        private void Start()
        {
            Score = 0;
        }

        private void Update()
        {
            _scoreLabel.text = $"Score: {Score}";
        }
        
        
        
    }
}
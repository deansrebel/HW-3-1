using TMPro;
using UnityEngine;

namespace Arkanoid.Game
{
    public class ScoreCount : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _scoreLabel;

        #endregion

        #region Properties

        public static int Score { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Score = 0;
        }

        private void Update()
        {
            _scoreLabel.text = $"Score: {Score}";
        }

        #endregion
    }
}
using System;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [Header("Visual")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _spriteFirstHit;
        [SerializeField] private Sprite _spriteSecondHit;

        [Header("Config")]
        [SerializeField] private int _lives = 1;
        [SerializeField] private int _score = 1;

        #endregion

        #region Events

        public event Action<Block> OnCreated;
        public event Action<Block> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _lives--;
            if (_lives == 0)
            {
                DestroyBlock();
                return;
            }

            UpdateView();
        }

        #endregion

        #region Private methods

        private void DestroyBlock()
        {
            ScoreCount.Score += _score;
            Destroy(gameObject);
        }

        private void UpdateView()
        {
            if (_lives == 2)
            {
                _spriteRenderer.sprite = _spriteFirstHit;
                return;
            }

            if (_lives == 1)
            {
                _spriteRenderer.sprite = _spriteSecondHit;
            }
        }

        #endregion
    }
}
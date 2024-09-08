using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Sprite _spriteFirstHit;
        [SerializeField] private Sprite _spriteSecondHit;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _lives = 1;

        private bool _isHit;

        #endregion
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _lives--;
            IsAlive();
        }

        private void IsAlive()
        {
            if (_lives == 0)
            {
                Destroy(gameObject);
            }

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
    }
}
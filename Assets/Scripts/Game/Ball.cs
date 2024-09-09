using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startDirection;

        private bool _isStarted;
        private Platform _platform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _platform = FindObjectOfType<Platform>();
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }
            MoveWithPlatform();
            
            if (!_isStarted && Input.GetMouseButtonDown(0))
            {
                StartFlying();
            }
        }

        private void MoveWithPlatform()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _platform.transform.position.x;
            transform.position = currentPosition;
        }

        private void StartFlying()
        {
            _isStarted = true;
            _rb.velocity = _startDirection;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Death"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        #endregion
    }
}
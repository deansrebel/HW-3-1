using UnityEngine;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startDirection;
        [SerializeField] private float _speed = 10;

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

        private void OnDrawGizmos()
        {
            if (!_isStarted)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_startDirection);
            }
            else
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
            }
        }

        #endregion

        #region Private methods

        private void MoveWithPlatform()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _platform.transform.position.x;
            transform.position = currentPosition;
        }

        private void StartFlying()
        {
            _isStarted = true;
            _rb.velocity = _startDirection.normalized * _speed;
        }

        #endregion
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startDirection;
        
        
        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = _startDirection;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Death")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
        }

        #endregion
    }
}
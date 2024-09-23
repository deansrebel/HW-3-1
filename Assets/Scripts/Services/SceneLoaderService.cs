using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoaderService
    {
        #region Public methods

        public static void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}
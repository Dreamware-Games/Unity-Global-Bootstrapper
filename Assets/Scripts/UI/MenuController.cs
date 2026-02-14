using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// Common utility controller for shared menu actions,
    /// such as scene loading and application quit.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
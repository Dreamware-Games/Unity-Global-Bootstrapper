using System.Collections;
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

        [SerializeField] private CanvasGroup menuGroup;

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(ExecuteWithDelay(() =>
            {
                SceneManager.LoadScene(sceneIndex);
            }));
        }

        public void QuitGame()
        {
            StartCoroutine(ExecuteWithDelay(() =>
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }));
        }

        private IEnumerator ExecuteWithDelay(System.Action action)
        {
            if (menuGroup != null)
                menuGroup.interactable = false;

            yield return new WaitForSeconds(0.5f);

            action?.Invoke();
        }

    }
}
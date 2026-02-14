using UnityEngine;

namespace Bootstrap
{
    /// <summary>
    /// Generic helper for bootstrapping global singleton systems.
    /// Ensures one instance exists, loads from Resources if needed,
    /// and marks it as DontDestroyOnLoad.
    /// </summary>
    internal static class Bootstrapper
    {
        internal static void Bootstrap<T>(string resourcesPath) where T : MonoBehaviour
        {
            T existing = Object.FindAnyObjectByType<T>();
            if (existing != null)
                return;

            T prefab = Resources.Load<T>(resourcesPath);
            if (prefab == null)
            {
                Debug.LogError($"{typeof(T).Name} prefab missing at Resources/{resourcesPath}");
                return;
            }

            T instance = Object.Instantiate(prefab);
            Object.DontDestroyOnLoad(instance.gameObject);
        }
    }
}
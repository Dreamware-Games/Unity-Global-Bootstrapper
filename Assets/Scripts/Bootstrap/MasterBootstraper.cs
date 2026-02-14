using Audio;
using UnityEngine;

namespace Bootstrap
{
    /// <summary>
    /// Central bootstrap entry point for core global systems.
    /// Instantiates required singleton managers in a defined dependency order
    /// before any scene loads, guaranteeing availability and predictable initialization.
    /// </summary>
    public static class MasterBootstraper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            Bootstrapper.Bootstrap<AudioManager>("Singletons/Audio Manager");
        }

    }
}
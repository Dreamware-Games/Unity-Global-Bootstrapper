using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    /// <summary>
    /// Global audio manager singleton.
    /// 
    /// Designed as the central entry point for game audio systems.
    /// In this minimal example, only UI sounds are handled.
    /// </summary>
    public sealed class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("UI one-shotters parent")]
        [SerializeField] private Transform uiOneShottersParent;

        private readonly List<AudioSource> uiOneShotters = new();
        private int currentIndex;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            // DontDestroyOnLoad isn't really neccessary here, since class is bootstrapped
            // It just reinforces persistence if instantiated outside the bootstrap flow
            DontDestroyOnLoad(gameObject);
            CacheAudioSources();
        }

        private void CacheAudioSources()
        {
            uiOneShotters.Clear();
            if (uiOneShottersParent == null)
                return;
            AudioSource[] sources =
                uiOneShottersParent.GetComponentsInChildren<AudioSource>(true);
            for (int i = 0; i < sources.Length; i++)
                uiOneShotters.Add(sources[i]);
        }

        public void PlayUIClip(AudioClip clip)
        {
            if (clip == null)
            {
                Debug.LogWarning("PlayUIClip called with null AudioClip");
                return;
            }
            if (uiOneShotters.Count == 0)
            {
                Debug.LogWarning("No UI AudioSources configured for AudioManager");
                return;
            }
            currentIndex = (currentIndex + 1) % uiOneShotters.Count;
            uiOneShotters[currentIndex].PlayOneShot(clip);
        }

    }
}
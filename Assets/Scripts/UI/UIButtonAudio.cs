using UnityEngine;
using UnityEngine.EventSystems;
using Audio;

namespace UI
{
    /// <summary>
    /// Small helper that plays UI sounds from standard Unity button events.
    /// Included here to demonstrate usage of the global AudioManager.
    /// </summary>
    public class UIButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [SerializeField] private AudioClip highlightClip;
        [SerializeField] private AudioClip pressClip;

        public void OnPointerEnter(PointerEventData eventData)
        {
            PlayHighlightClip();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PlayPressClip();
        }

        private void PlayHighlightClip()
        {
            AudioManager.Instance?.PlayUIClip(highlightClip);
        }

        private void PlayPressClip()
        {
            AudioManager.Instance?.PlayUIClip(pressClip);
        }

    }
}
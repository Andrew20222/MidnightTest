using System.Collections;
using Items.View;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BasePanel : MonoBehaviour,IHidenable
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float duration;
        
        public void Show()
        {
            StartCoroutine(FadeAlpha(1));
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.ignoreParentGroups = true;
        }

        public void Hide()
        {
            StartCoroutine(FadeAlpha(0));
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.ignoreParentGroups = false;
        }
        
        private IEnumerator FadeAlpha(float targetAlpha)
        {
            var currentTime = 0f;
            var startAlpha = canvasGroup.alpha;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
                canvasGroup.alpha = alpha;
                yield return null;
            }
        }
    }
}
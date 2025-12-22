using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace _00.Works.KDS._02.Script
{
    public class UpgradeCardUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rectTransform;

        private void Awake()
        {
            // 카드 오브젝트는 반드시 Active 상태
            canvasGroup.alpha = 0f;
            rectTransform.localScale = Vector3.one * 0.5f;
        }

        public Tween ShowTween()
        {
            Debug.Log($"{name} ShowTween 실행");

            Sequence seq = DOTween.Sequence()
                .SetUpdate(true);

            seq.Append(canvasGroup.DOFade(1f, 0.2f));
            seq.Join(
                rectTransform.DOScale(1f, 0.2f)
                    .SetEase(Ease.OutBack)
            );

            return seq;
        }
    }
}

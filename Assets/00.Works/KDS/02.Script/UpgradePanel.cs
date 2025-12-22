using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

namespace _00.Works.KDS._02.Script
{
    public class UpgradePanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform panelTransform;
        [SerializeField] private List<UpgradeCardUI> cards;

        private Sequence _sequence;

        private void Awake()
        {
            // 패널은 비활성화 상태에서 시작
            canvasGroup.alpha = 0f;
            panelTransform.localScale = Vector3.one * 0.8f;

            gameObject.SetActive(false);
        }

        public void Show()
        {
            Debug.Log("UpgradePanel Show 호출됨");

            // 반드시 먼저 활성화
            gameObject.SetActive(true);

            // 게임 정지
            Time.timeScale = 0f;

            // 기존 시퀀스 제거
            _sequence?.Kill();

            // UI는 TimeScale 무시
            _sequence = DOTween.Sequence()
                .SetUpdate(true);

            // 패널 등장
            _sequence.Append(canvasGroup.DOFade(1f, 0.25f));
            _sequence.Join(
                panelTransform.DOScale(1f, 0.25f)
                    .SetEase(Ease.OutBack)
            );

            // 카드 순차 등장
            foreach (var card in cards)
            {
                _sequence.Append(card.ShowTween());
            }
        }

        public void Close()
        {
            Debug.Log("UpgradePanel Close 호출됨");

            _sequence?.Kill();

            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}

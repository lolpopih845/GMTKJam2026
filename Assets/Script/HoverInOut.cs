using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoverInOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Reference")]
    [SerializeField] private RectTransform hoverInObject;
    [SerializeField] private RectTransform hoverOutObject;

    [Header("Tween")]
    [SerializeField] private Vector2 hoverInIn = new(0.5f, 0.5f);
    [SerializeField] private Vector2 hoverInOut = new(1.5f, 1.5f);
    [SerializeField] private Vector2 hoverOutIn = new(0.5f, 0.5f);
    [SerializeField] private Vector2 hoverOutOut = new(1.5f, 1.5f);
    [SerializeField] private float tweenDuration = 0.5f;

    void Awake()
    {
        DOTween.SetTweensCapacity(1000, 50);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverInObject)
            hoverInObject.DOPivot(new Vector2(hoverInIn.x, hoverInIn.y), tweenDuration);
        if (hoverOutObject)
            hoverOutObject.DOPivot(new Vector2(hoverOutOut.x, hoverOutOut.y), tweenDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverInObject)
            hoverInObject.DOPivot(new Vector2(hoverInOut.x, hoverInOut.y), tweenDuration);
        if (hoverOutObject)
            hoverOutObject.DOPivot(new Vector2(hoverOutIn.x, hoverOutIn.y), tweenDuration);
    }
}
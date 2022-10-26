using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WireDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform WireRect;
    public Canvas UICanvas;
    public CanvasGroup UICanvasGroup;
    public Vector2 InitialPosition;

    public void Awake()
    {
        WireRect = GetComponent<RectTransform>();
        InitialPosition = WireRect.anchoredPosition;
        UICanvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        UICanvasGroup.alpha = 0.5f;
        UICanvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        UICanvasGroup.alpha = 1.0f;
        UICanvasGroup.blocksRaycasts = !MainManager.Instance.Obstacle3Components[gameObject.name];
    }
    public void OnDrag(PointerEventData eventData)
    {
        WireRect.anchoredPosition += eventData.delta / UICanvas.scaleFactor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JewelDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform JewelRect;
    public Canvas UICanvas;
    public CanvasGroup UICanvasGroup;
    public Vector2 InitialPosition;

    public void Awake()
    {
        JewelRect = GetComponent<RectTransform>();
        InitialPosition = JewelRect.anchoredPosition;
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
        UICanvasGroup.blocksRaycasts = !MainManager.Instance.Level1Items[gameObject.name];
    }
    public void OnDrag(PointerEventData eventData)
    {
        JewelRect.anchoredPosition += eventData.delta / UICanvas.scaleFactor;
    }
}


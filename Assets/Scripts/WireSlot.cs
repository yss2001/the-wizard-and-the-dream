using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WireSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            string Id = gameObject.name;
            Id = Id.Substring(0, Id.Length-4);
            if (MainManager.Instance.Obstacle3Components[Id])
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.gameObject.GetComponent<WireDrag>().InitialPosition;
                return;
            }
            if (Id == eventData.pointerDrag.name)
            {
                MainManager.Instance.Obstacle3Components[Id] = true;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                string Type = Id.Substring(Id.Length - 4);
                if (Type != "Wire")
                {
                    float Shift = 8.0f;
                    if (Id == "MaroonArea")
                        Shift = 15.0f;
                    Vector3 Position = eventData.pointerDrag.GetComponent<RectTransform>().position;
                    eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(Position.x, Position.y + Shift);
                    Vector3 Pos3D = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition3D;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(Pos3D.x, Pos3D.y, 0.0f);
                }
            }
            else
            {
                MainManager.Instance.Obstacle3Components[Id] = false;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.gameObject.GetComponent<WireDrag>().InitialPosition;
            }
        }
    }
}

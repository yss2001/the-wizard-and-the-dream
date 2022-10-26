using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class JewelSlot : MonoBehaviour, IDropHandler
{
    public TextMeshProUGUI Description;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            string Id = gameObject.name;
            Id = Id.Substring(0, 1);
            if (MainManager.Instance.Level1Items[Id])
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.gameObject.GetComponent<JewelDrag>().InitialPosition;
                return;
            }
            if (Id == eventData.pointerDrag.name)
            {
                MainManager.Instance.Level1Items[Id] = true;
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(Id+"HoldFull");
                eventData.pointerDrag.gameObject.SetActive(false);

                foreach(KeyValuePair<string, bool> Item in MainManager.Instance.Level1Items)
                {
                    if (Item.Value == false)
                    {
                        return;
                    }
                }
                MainManager.Instance.Level1TaskDone = true;
                Description.text = "All items are correctly placed! You can capture the key now.";
            }
            else
            {
                MainManager.Instance.Level1Items[Id] = false;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.gameObject.GetComponent<JewelDrag>().InitialPosition;
            }
        }
    }
}

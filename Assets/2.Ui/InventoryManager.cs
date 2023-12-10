using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemDateBase itemDate;
    [SerializeField] private Image[] inventory = new Image[12];
    public GameObject clickedObject;
    private void Awake()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i].sprite = itemDate.Item[i];
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var item in inventory)
        {
            if (item.gameObject == eventData.pointerCurrentRaycast.gameObject)
            {
                clickedObject = eventData.pointerCurrentRaycast.gameObject;
                clickedObject.TryGetComponent(out Image clickItem);
                BingoManager.Instance.CurrentItem = clickItem.sprite;
                break;
            }
        }
    }
}

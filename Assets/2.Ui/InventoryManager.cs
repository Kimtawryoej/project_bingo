using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemDateBase itemDate;
    [SerializeField] private Image[] inventory = new Image[5];
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
        clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(clickedObject.TryGetComponent(out Image clickItem));
    }
}
        //clickedObject.TryGetComponent(out Sprite clickItem);
        //BingoManager.Instance.CurrentItem = clickItem.sprite;

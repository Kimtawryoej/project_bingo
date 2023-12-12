using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using  UnityEditor;

public class InventoryManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ItemDateBase itemDate;
    [SerializeField] private Image[] inventory = new Image[12];
    [SerializeField] private Image skilltextImage;
    [SerializeField] private Text skilltextImageText;
    [SerializeField] private string[] skilltext = new string[12];
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
        foreach (Image item in inventory)
        {
            if (item.gameObject == eventData.pointerCurrentRaycast.gameObject)
            {
                foreach (Image item2 in RandomChoice.Instance.Slot)
                {
                    if (item.sprite.Equals(item2.sprite))
                    {
                        clickedObject = eventData.pointerCurrentRaycast.gameObject;
                        clickedObject.TryGetComponent(out Image clickItem);
                        BingoManager.Instance.CurrentItem = clickItem.sprite;
                        break;
                    }
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].gameObject == eventData.pointerCurrentRaycast.gameObject)
            {
                skilltextImageText.text = skilltext[i];
                
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].gameObject == eventData.pointerCurrentRaycast.gameObject)
            {
                skilltextImageText.text = "";
            }
        }

    }
}

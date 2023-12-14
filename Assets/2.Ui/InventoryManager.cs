using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class InventoryManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemDateBase itemDate;
    [SerializeField] private Image[] inventory = new Image[12];
    [SerializeField] private Image skilltextImage;
    [SerializeField] private Text skilltextImageText;
    [SerializeField] private string[] skilltext = new string[12];
    public GameObject clickedObject;
    
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                inventory[(j + (4 * i))].sprite = itemDate.Items[i, j];
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].gameObject == eventData.pointerCurrentRaycast.gameObject)
            {
                skilltextImageText.text = skilltext[i];
                foreach (Image item2 in RandomChoice.Instance.Slot)
                {
                    if (inventory[i].sprite.Equals(item2.sprite))
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
}

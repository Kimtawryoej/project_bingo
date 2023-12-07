using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BingoManager : SingleTone<BingoManager>, IPointerClickHandler
{
    [SerializeField] private Image[] slot = new Image[16];

    public LinkedList<Image> SlotItem { get; set; } = new LinkedList<Image>();
    public Queue<Image> OneSaveItem { get; set; } = new Queue<Image>();
    public Sprite CurrentItem { get; set; }

    private void Start()
    {
        Debug.Log(CurrentItem);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(CurrentItem);
        if (CurrentItem != null)
        {
            foreach (var item in slot)
            {
                if (item.gameObject == eventData.pointerCurrentRaycast.gameObject)
                {
                    item.sprite = CurrentItem;
                    break;
                }
            }
        }
    }
}


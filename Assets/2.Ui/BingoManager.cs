using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BingoManager : SingleTone<BingoManager>, IPointerClickHandler
{
    [SerializeField] private Image[] slot = new Image[16];
    private Sprite normalImg;
    private QueueWithLikedList<Image> OneSaveItem = new QueueWithLikedList<Image>();
    //public Queue<Image> OneSaveItem { get; set; } = new Queue<Image>();
    public Sprite CurrentItem { get; set; }

    private void Start()
    {
        normalImg = slot[0].sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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


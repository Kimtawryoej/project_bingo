using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BingoManager : SingleTone<BingoManager>, IPointerClickHandler, I_Obsever
{
    [SerializeField] private ActionDateBase m_ActionDateBase;
    [SerializeField] private Image[] slot = new Image[16];
    [SerializeField] private Sprite normalImg;
    private QueueWithLikedList<Sprite> OneSaveItem = new QueueWithLikedList<Sprite>();
    public Sprite CurrentItem { get; set; }
    private GameObject clickObject;
  
    public override void Awake()
    {
        base.Awake();
        m_ActionDateBase.ActionReset();
    }
    private void Start()
    {
        normalImg = slot[0].sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(clickObject.TryGetComponent(out Image ClickObjectSp));
        if (CurrentItem != null && ClickObjectSp.sprite.Equals(normalImg) && GameSystem.Instance.Condition.Repeat.TurnSt)
        {
            foreach (var item in slot)
            {
                if (item.gameObject == clickObject)
                {
                    item.sprite = CurrentItem;
                    break;
                }
            }
        }
        else if (!ClickObjectSp.sprite.Equals(normalImg) && GameSystem.Instance.Condition.Repeat.TurnEnd)
        {
            OneSaveItem.Add(ClickObjectSp.sprite);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < OneSaveItem.Count(); i++)
        {
            Debug.Log(m_ActionDateBase.Actions[OneSaveItem.Push()]);
        }
    }
}


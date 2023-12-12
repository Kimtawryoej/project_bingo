using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BingoManager : SingleTone<BingoManager>, IPointerClickHandler
{
    [SerializeField] private ActionDateBase m_ActionDateBase;
    public Image[] slot = new Image[16]; //�̰� private�� �ٲٰ� �ؾ��� �迭 ������Ƽ ã�ƺ���
    [SerializeField] private Sprite normalImg;
    public Sprite NormalImg { get => normalImg; }
    private QueueWithLikedList<Image> OneSaveItem = new QueueWithLikedList<Image>();
    public Sprite CurrentItem { get; set; }
    private GameObject clickObject;

    public override void Awake()
    {
        base.Awake();
        m_ActionDateBase.ActionReset();
    }
    private void Start()
    {
        StartCoroutine(ActionPl());
        normalImg = slot[0].sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickObject = eventData.pointerCurrentRaycast.gameObject;
        clickObject.TryGetComponent(out Image ClickObjectSp);
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
            OneSaveItem.Add(ClickObjectSp);
        }
    }

    IEnumerator ActionPl()
    {
        WaitForSeconds wait = new WaitForSeconds(2.5f);
        while (true)
        {
            yield return new WaitUntil(() => GameSystem.Instance.Condition.Repeat.Battle);
            for (int i = OneSaveItem.Count(); i > 0; i--)
            {
                m_ActionDateBase.Actions[OneSaveItem.Push().sprite]();
                yield return Player.Instance.AniStop("2_Attack_Bow", "Attack"); //�׼Ǿȿ� �ִϸ��̼��� �����ϴ� �ڵ尡 �������� ����
            }
            OneSaveItem.Clear();
            yield return wait;
            yield return Monster.Instance.Attack();
        }
    }


}


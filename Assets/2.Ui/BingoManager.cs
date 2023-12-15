using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class BingoManager : SingleTone<BingoManager>, IPointerClickHandler, I_ObseverManager
{
    enum Bingo { Attack, Defense = 0, Special = 0 }
    public List<I_Obsever> MonsterObsevers = new List<I_Obsever>();
    [SerializeField] private ActionDateBase m_ActionDateBase;
    /*public Image[] slot = new Image[9];*/ //이거 private로 바꾸고 해야함 배열 프로퍼티 찾아보삼
    public Image[,] Slot = new Image[3, 3];
    [SerializeField] private Sprite normalImg;
    public Sprite NormalImg { get => normalImg; }
    private QueueWithLikedList<Image> OneSaveItem = new QueueWithLikedList<Image>();
    public Sprite CurrentItem { get; set; }
    private GameObject clickObject;
    private Action BingoAction;



    public override void Awake()
    {
        base.Awake();
        BingoSet();
    }

    private void Start()
    {
        StartCoroutine(ActionPl());
        normalImg = Slot[0, 0].sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickObject = eventData.pointerCurrentRaycast.gameObject;
        clickObject.TryGetComponent(out Image ClickObjectSp);
        if (CurrentItem != null && ClickObjectSp.sprite.Equals(normalImg) && GameSystem.Instance.Condition.Repeat.TurnSt)
        {
            foreach (var item in Slot)
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
            yield return BingoCheck();
            MonsterManager.Instance.MonsterCount[MonsterManager.Instance.Index].TryGetComponent(out Monster monster);//고쳐야함
            for (int i = OneSaveItem.Count(); i > 0; i--)
            {
                if (monster.gameObject.activeSelf)
                {
                    m_ActionDateBase.Actions[OneSaveItem.Push().sprite]();
                    yield return UI.Instance.SkillNameOff(m_ActionDateBase.OneSaveItem.Push());

                    //Debug.Log(m_ActionDateBase.OneSaveItem.Push());
                    yield return Player.Instance.AniStop("2_Attack_Bow", "Attack"); //액션안에 애니메이션을 실행하는 코드가 있을때만 실행
                }
            }
            OneSaveItem.Clear();
            yield return wait;
            if (monster.gameObject.activeSelf)
            {
                Debug.Log(monster.gameObject);
                yield return monster.Attack(() => NotifyObserver<int>(MonsterObsevers, 1));
            }
            else
            {
                MonsterManager.Instance.NextMonster();
                GameSystem.Instance.Condition.Repeat.Battle = false;
                GameSystem.Instance.Condition.Repeat.TurnSt = true;
                GameSystem.Instance.TrunEnd();
            }
        }
    }

    private void BingoSet()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Slot[i, j] = gameObject.GetComponentsInChildren<Image>()[(j + (3 * i)) + 1];
            }
        }
    }

    private IEnumerator BingoCheck()
    {
        int f;
        int l;

        for (int q = 0; q < 2; q++)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (q == 0)
                    {
                        f = i;
                        l = j;
                    }
                    else
                    {
                        f = j;
                        l = i;
                    }
                    for (int o = 0; o < 3; o++)
                    {
                        for (int t = 0; t < 4; t++)
                        {
                            if (Slot[f, l].sprite == GameSystem.Instance.ItemDateBase.Items[o, t])
                            {
                                switch (o)
                                {
                                    case 0:
                                        m_ActionDateBase.Attack++;
                                        break;
                                    case 1:
                                        m_ActionDateBase.Defense++;
                                        break;
                                    case 2:
                                        m_ActionDateBase.Special++;
                                        break;
                                }
                            }
                        }
                    }

                }
                if (m_ActionDateBase.Attack >= 2) { yield return UI.Instance.SkillNameOff("공격업"); Player.Instance.ChangeAttackPowerUp(1); Debug.Log("전투"); }
                else if (m_ActionDateBase.Defense >= 2) { yield return UI.Instance.SkillNameOff("방어력"); Player.Instance.ChangeDeefense(1); Debug.Log("지원"); }
                else if (m_ActionDateBase.Special >= 2) { yield return UI.Instance.SkillNameOff("공격&방어"); Player.Instance.ChangeDeefense(1); Player.Instance.ChangeAttackPowerUp(1); Debug.Log("스페셜"); }
                
                m_ActionDateBase.Attack = 0; m_ActionDateBase.Defense = 0; m_ActionDateBase.Special = 0;
            }
        }

    }

    #region Obsever
    public void Add(I_Obsever obsever, int index)
    {
        MonsterObsevers.Add(obsever);
    }
    public void Delete(I_Obsever obsever, int index)
    {
        MonsterObsevers.Remove(obsever);
    }
    public void NotifyObserver<T>(List<I_Obsever> obsevers, T value)
    {
        foreach (I_Obsever obsever in obsevers)
        {
            obsever.Refresh<int>(Convert.ToInt32(value));
        }
    }
    #endregion
}


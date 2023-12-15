using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : SingleTone<GameSystem>, I_Obsever
{
    [SerializeField] private ConditionDateBase conditionDateBase;
    [SerializeField] private ActionDateBase actionDateBase;
    [SerializeField] private ItemDateBase itemDateBase;
    public ItemDateBase ItemDateBase => itemDateBase;
    public ConditionDateBase Condition => conditionDateBase;
    public override void Awake()
    {
        base.Awake();
        conditionDateBase.Repeat.TurnSt = true;
        itemDateBase.ItemsSet();
        conditionDateBase.BoolSet();
        actionDateBase.ActionReset();
    }

    private void Start()
    {

        UI.Instance.Add(this, 1);
        UI.Instance.Add(Condition, 2);
        UI.Instance.Add(RandomChoice.Instance, 1);
    }

    public void TrunEnd()
    {
        Player.Instance.ChangeAttackPowerUp(-Player.Instance.UnitStat.AttackPowerUp);
        Player.Instance.ChangeDeefense(-Player.Instance.UnitStat.Deefense);
        foreach (Image i in BingoManager.Instance.Slot)
        {
            i.sprite = BingoManager.Instance.NormalImg;
        }
    }

    public IEnumerator waiting(bool condition)
    {
        yield return new WaitUntil(() => condition == false);
    }


    public void Refresh<T>(T value)
    {
        //Debug.Log("¿¸≈ı");
        Condition.Repeat.TurnEnd = !Convert.ToBoolean(value);
        Condition.Repeat.Battle = Convert.ToBoolean(value);
    }
}
public class QueueWithLikedList<T> : MonoBehaviour
{
    private T OneDestory;
    private LinkedList<T> Queue = new LinkedList<T>();
    public void Add(T Object) { if (!Queue.Contains(Object)) { Queue.AddFirst(Object); } }
    public T Push() { OneDestory = Queue.Last(); Queue.Remove(OneDestory); return OneDestory; }
    public void Remove(T Object) { Queue.Remove(Object); }
    public void Clear() { Queue.Clear(); }
    public int Count() { return Queue.Count; }
}

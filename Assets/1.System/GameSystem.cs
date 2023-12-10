using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSystem : SingleTone<GameSystem>, I_Obsever
{
    [SerializeField] private ConditionDateBase condition;
    public ConditionDateBase Condition { get { return condition; } set => condition = value; }
    private int weight = 1;
    [SerializeField] private bool check;
    public bool Check
    {
        get
        {
            bool onetry = check;
            check = false;
            return onetry;
        }
        set
        {
            check = value;
        }
    }
    public override void Awake()
    {
        base.Awake();
        condition.Repeat.TurnSt = true;
        condition.BoolSet();
    }

    private void Start()
    {
        
        UI.Instance.Add(this, 1);
        UI.Instance.Add(Condition, 2);
        StartCoroutine(turn());
    }


    private IEnumerator turn()
    {
        WaitForSeconds Wait = new WaitForSeconds(3);
        while (true)
        {
            yield return waiting(Condition.Repeat.TurnSt);

            if(Condition.Repeat.TurnEnd)
                yield return timer(Wait);

            yield return waiting(Condition.Repeat.TurnEnd);

            yield return waiting(Condition.Repeat.Battle);

            //if (Check)
            //{
            //    Debug.Log("멈춤");
            //    weight = 1;
            //    yield return waiting(Condition.TurnMethod());//다른 조건을 줘야함 => 적의 행동이 모두 끝난후
            //}
            //else
            //{
            //    weight *= 2;
            //    //Debug.Log(weight);
            //}
        }
    }

    public IEnumerator timer(WaitForSeconds wait)
    {
        yield return wait;
        weight *= 2;
    }

    public IEnumerator waiting(bool condition)
    {
        yield return new WaitUntil(() => condition == false);
    }


    public void Refresh()
    {
        Debug.Log("전투");
        Condition.Repeat.TurnEnd = false;
        Condition.Repeat.Battle = true;
        weight = 1;
    }
}
public class QueueWithLikedList<T> : MonoBehaviour
{
    private T OneDestory;
    private LinkedList<T> Queue = new LinkedList<T>();
    public void Add(T Object) { Queue.AddFirst(Object); }
    public T Push() { OneDestory = Queue.Last(); Queue.Remove(OneDestory); return OneDestory; }
    public void Remove(T Object) { Queue.Remove(Object); }
    public void Clear() { Queue.Clear(); }
    public int Count() { return Queue.Count; }
}

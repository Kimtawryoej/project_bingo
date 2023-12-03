using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour, I_Obsever
{
    [SerializeField] private ConditionDateBase condition;

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

    private void Start()
    {
        UI.Instance.Add(this, 1);
        UI.Instance.Add(condition, 2);
        StartCoroutine(turn());
    }


    private IEnumerator turn()
    {
        WaitForSeconds Wait = new WaitForSeconds(3);
        while (true)
        {
            if (Check)
            {
                Debug.Log("����");
                weight = 1;
                yield return waiting(condition.TurnMethod(), () => turn());
            }
            else
            {
                weight *= 2;
                Debug.Log(weight);
            }
            yield return Wait;// ����*
        }
    }


    private IEnumerator waiting(Func<bool> condition, Func<IEnumerator> StCoroutine)
    {
        yield return new WaitUntil(condition);
    }


    public void Refresh()
    {
        Check = true;
        weight = 1;
    }
}

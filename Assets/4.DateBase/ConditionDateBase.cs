using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionDateBase", menuName = "ConditionDateBase", order = 1)]
public class ConditionDateBase : ScriptableObject, I_Obsever
{
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


    public void Refresh()
    {
        Check = true;
    }
    public Func<bool> TurnMethod()
    {
        return () => Check;
    }
}

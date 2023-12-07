using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ActionDateBase", menuName = "ActionDateBase", order = 1)]
public class ActionDateBase : ScriptableObject
{
    [SerializeField] ItemDateBase Item;
    Hashtable Actions;
    //public Action  AcGather()
    //{
        
    //    return
    //}
    public void  ActionReset()
    {
        Actions = new Hashtable()
        {
            {Item.Item[0],()=>}
        };
    }
}

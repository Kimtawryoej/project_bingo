using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ActionDateBase", menuName = "ActionDateBase", order = 1)]
public class ActionDateBase : ScriptableObject
{
    [SerializeField] ItemDateBase Item;
    public Dictionary<Sprite, string> Actions;
    Func<string> skill1 = () => "skill1";
    Func<string> skill2 = () => "skill2";
    Func<string> skill3 = () => "skill3";
    Func<string> skill4 = () => "skill4";
    Func<string> skill5 = () => "skill5";
    public void ActionReset()
    {
        Actions = new Dictionary<Sprite, string>()
        {
            {Item.Item[0],skill1()},
            {Item.Item[1],skill2()},
            {Item.Item[2],skill3()},
            {Item.Item[3],skill4()},
            {Item.Item[4],skill5()},
        };
        Debug.Log("¼³Á¤");
    }
}

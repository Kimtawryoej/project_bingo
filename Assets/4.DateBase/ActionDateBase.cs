using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ActionDateBase", menuName = "ActionDateBase", order = 1)]
public class ActionDateBase : ScriptableObject
{
    [SerializeField] ItemDateBase Item;
    public Dictionary<Sprite, Action> Actions;
    private Action attackSkill1 = () => Player.Instance.Anim.SetBool("Attack",true);
    private Action attackSkill2 = () => Player.Instance.Anim.SetBool("Attack", true);
    private Action attackSkill3 = () => Player.Instance.Anim.SetBool("Attack", true);
    private Action attackSkill4 = () => Player.Instance.Anim.SetBool("Attack", true);
    private Action attackSkill5 = () => Player.Instance.Anim.SetBool("Attack", true);
    public void ActionReset()
    {
        Actions = new Dictionary<Sprite, Action>()
        {
            {Item.Item[0],attackSkill1},
            {Item.Item[1],attackSkill2},
            {Item.Item[2],attackSkill3},
            {Item.Item[3],attackSkill4},
            {Item.Item[4],attackSkill5},
        };
        Debug.Log("¼³Á¤");
    }
}

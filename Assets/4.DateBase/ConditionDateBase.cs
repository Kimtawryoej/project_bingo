using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public struct Repeat
{
    public bool TurnSt { get; set; }
    public bool TurnEnd {  get; set; }
    public bool Battle {  get; set; }
}
[CreateAssetMenu(fileName = "ConditionDateBase", menuName = "ConditionDateBase", order = 1)]
public class ConditionDateBase : ScriptableObject, I_Obsever
{
    public Repeat Repeat;
    public void Refresh<T>(T value)
    {
        Debug.Log("³¡");
        Repeat.TurnSt = !Convert.ToBoolean(value);
        Repeat.TurnEnd = Convert.ToBoolean(value);
    }
    public void BoolSet()
    {
        Repeat.TurnEnd = false;
        Repeat.Battle = false;
    }
}

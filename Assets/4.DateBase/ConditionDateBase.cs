using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public struct Repeat
{
    public bool TurnSt {  get; set; }
    public bool TurnEnd {  get; set; }
    public bool Battle {  get; set; }
}
[CreateAssetMenu(fileName = "ConditionDateBase", menuName = "ConditionDateBase", order = 1)]
public class ConditionDateBase : ScriptableObject, I_Obsever
{
    public Repeat Repeat;
    //public bool TurnSt
    //{
    //    get
    //    {
    //        if (repeat.TurnSt)
    //            return Set(out repeat.TurnSt);
    //        else return false;
    //    }
    //    set
    //    {
    //        repeat.TurnSt = value;
    //    }
    //}
    //public bool TurnEnd
    //{
    //    get
    //    {
    //        if (repeat.TurnEnd)
    //            return Set(out repeat.TurnEnd);
    //        else return false;
    //    }
    //    set
    //    {
    //        repeat.TurnEnd = value;
    //    }
    //}
    //public bool Battle
    //{
    //    get
    //    {
    //        if (repeat.Battle)
    //            return Set(out repeat.Battle);
    //        else return false;
    //    }
    //    set
    //    {
    //        repeat.Battle = value;
    //    }
    //}

    public bool Set(out bool boolvalue)
    {
        boolvalue = true;
        bool onetry = boolvalue;
        boolvalue = false;
        return onetry;
    }
    public void Refresh()
    {
        Repeat.TurnSt = false;
        Repeat.TurnEnd = true; 
    }
    public bool TurnMethod(bool selectvalue)
    {
        return selectvalue;
    }



}

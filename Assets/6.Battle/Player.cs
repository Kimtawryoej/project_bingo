using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit, I_Obsever, Hitcheck
{
    public static Player Instance;
    override protected void Awake()
    {
        Monster.Instance.Add(this, 1);
        Instance = this;
        animator = GetComponent<Animator>();
        StartCoroutine(HiEffect());
    }
    public void Refresh<T>(T value)
    {
        if (UnitStat.Deefense <= 0)
        {
            hitcheck = true;
            ChangeHp(-Convert.ToInt32(value));
        }
        else ChangeDeefense(-Convert.ToInt32(value));
    }
    public IEnumerator HiEffect()
    {
        while (true)
        {
            yield return new WaitUntil(() => hitcheck);
            yield return Effect.Instance.EffectsSys(transform.position, 0);
            hitcheck = false;
        }
    }
}

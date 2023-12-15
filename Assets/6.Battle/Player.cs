using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit, I_Obsever, Hitcheck
{
    public static Player Instance;
    override protected void Awake()
    {
        //MonsterManager.Instance.MonsterCount.TryGetComponent(out Monster monster);
        //foreach (GameObject p in MonsterManager.Instance.MonsterCount)
        //{
        //    p.TryGetComponent(out Monster monster);
        //    monster.Add(this, 1);
        //}
        BingoManager.Instance.Add(this, 1);
        Instance = this;
        animator = GetComponent<Animator>();
        StartCoroutine(HiEffect());
    }
    public void Refresh<T>(T value)
    {
        Debug.Log("¸ÂÀ½");
        if (UnitStat.Deefense <= 0)
        {
            Debug.Log(value);
            hitcheck = true;
            ChangeHp(-Convert.ToInt32(value));
        }
        else { ChangeDeefense(-Convert.ToInt32(value)); hitcheck = true; }
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit, I_Obsever, I_ObseverManager, Hitcheck
{
    [SerializeField] private ActionDateBase m_ActionDateBase;
    public List<I_Obsever> MonsterObsevers = new List<I_Obsever>();
    public static Monster Instance;
    override protected void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        m_ActionDateBase.Add(this, 1);
        StartCoroutine(HiEffect());
    }

    public IEnumerator Attack()
    {
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            Anim.SetBool("Attack", true);
            NotifyObserver<int>(MonsterObsevers, UnitStat.AttackPower);
            yield return AniStop("2_Attack_Bow", "Attack");
        }
        GameSystem.Instance.Condition.Repeat.Battle = false;
        GameSystem.Instance.Condition.Repeat.TurnSt = true;
        GameSystem.Instance.TrunEnd();
    }
    public IEnumerator HiEffect()
    {
        while (true)
        {
            yield return new WaitUntil(() => hitcheck);
            yield return Effect.Instance.EffectsSys(transform.position, 1);
            hitcheck = false;
        }
    }
    #region Obsevers
    public void Refresh<T>(T value)
    {
        hitcheck = true;
        ChangeHp(-Convert.ToInt32(value));
    }

    public void Add(I_Obsever obsever, int index)
    {
        MonsterObsevers.Add(obsever);
    }
    public void Delete(I_Obsever obsever, int index)
    {
        MonsterObsevers.Remove(obsever);
    }
    public void NotifyObserver<T>(List<I_Obsever> obsevers, T value)
    {
        foreach (I_Obsever obsever in obsevers)
        {
            obsever.Refresh<int>(Convert.ToInt32(value));
        }
    }
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit, I_Obsever, Hitcheck
{
    [SerializeField] private ActionDateBase m_ActionDateBase;
    public static Monster Instance;
    override protected void OnEnable()
    {
        ReSetStat();
        StartCoroutine(HiEffect());
        hitcheck = false;
    }
    override protected void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        m_ActionDateBase.Add(this, 1);

    }

    public IEnumerator Attack(Action play)
    {
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            Anim.SetBool("Attack", true);
            play();
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


    #endregion
}

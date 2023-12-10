using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public static Monster Instance;
    override protected void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public IEnumerator Attack()
    {
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            Anim.SetBool("Attack", true);
            yield return AniStop("2_Attack_Bow", "Attack");
        }
        GameSystem.Instance.Condition.Repeat.Battle = false;
        GameSystem.Instance.Condition.Repeat.TurnSt = true;
    }
}

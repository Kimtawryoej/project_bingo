using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct UnitStatInfo
{
    public int MaxHp;
    public int MinHp;
    public float MoveSpeed;
    public int AttackPower;
    public float Deefense;
    public int AttackPowerUp;
}


//[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(Rigidbody2D))]
public abstract class Unit : MonoBehaviour
{
    #region ����
    [SerializeField] protected bool hitcheck;
    [SerializeField] protected UnitStatInfo unitStat;
    public UnitStatInfo UnitStat => unitStat;

    [Space]
    [SerializeField] protected GameObject attackEffect;
    [SerializeField] protected GameObject dashEffect;

    [Space]
    [SerializeField] private AudioClip hitSound;

    [SerializeField] protected int currentHp;
    public int CurrentHp => currentHp;

    protected bool isDead = false;

    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    [SerializeField] protected Animator animator;
    public Animator Anim => animator;

    protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;
    #endregion

    protected virtual void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        //rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        ReSetStat();
    }

    #region ReSet
    protected void ReSetStat()
    {
        ResetHp();
        //ResetSpeed();
        //ResetAttackPower();
    }

    protected virtual void ResetHp()
    {
        currentHp = unitStat.MaxHp;
    }

    //protected abstract void ResetSpeed();

    //protected abstract void ResetAttackPower();
    #endregion

    #region Hp
    //public virtual void TakeDamage(int damageValue)
    //{
    //    ChangeHp(-damageValue);
    //    HitEffect();
    //    HitSound();

    //    void HitEffect()
    //    {
    //        GameObject hitEffectSpawn = Instantiate(hitEffect);
    //        Vector3 randomPos = transform.position + (Vector3)Random.insideUnitCircle * 0.5f;
    //        hitEffectSpawn.transform.position = randomPos;
    //    }

    //    void HitSound()
    //    {
    //        SoundSystem.Instance.PlayFXSound(hitSound, 0.5f);
    //    }
    //}

    public virtual void SetHp(int healValue)
    {
        ChangeHp(healValue);
    }

    public virtual void ChangeHp(int value)
    {
        if (!isDead)
        {
            ClampHp(ref value);
            if (CurrentHp <= UnitStat.MinHp)
            {
                Death();
                isDead = true;
            }
        }
    }

    protected void ClampHp(ref int value)
    {
        if (CurrentHp + value >= UnitStat.MaxHp)
        {
            currentHp = UnitStat.MaxHp;
        }

        else if (CurrentHp + value <= UnitStat.MinHp)
        {
            currentHp = UnitStat.MinHp;
        }

        else { currentHp += value; }
    }
    #endregion

    #region GetValue
    public float GetMoveSpeed()
    {
        return unitStat.MoveSpeed;
    }

    public int GetHp()
    {
        return currentHp;
    }

    public int GetMaxHp()
    {
        return unitStat.MaxHp;
    }

    public int GetAttackPower()
    {
        return unitStat.AttackPower;
    }
    #endregion

    #region Defence
    public void ChangeDeefense(float value)
    {
        unitStat.Deefense += value;
    }
    #endregion

    #region AttackPowerUp
    public void ChangeAttackPowerUp(int value)
    {
        unitStat.AttackPowerUp += value;
    }
    #endregion
    protected virtual void Death()
    {
        animator.SetBool("Death", true);
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
        //scenemanager.loadscene(0);
    }

    public IEnumerator AniStop(string Aniname, string Aniset)
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        animator.SetBool(Aniset, false);
        yield return new WaitForSeconds(2.5f);
    }
}
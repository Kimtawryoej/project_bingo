using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ActionDateBase", menuName = "ActionDateBase", order = 1)]
public class ActionDateBase : ScriptableObject, I_ObseverManager
{
    [SerializeField] ItemDateBase Item;
    public int Attack = 0, Defense = 0, Special = 0;
    public List<I_Obsever> PlayerObsevers = new List<I_Obsever>();
    public Dictionary<Sprite, Action> Actions;
    private Action attackSkill1;
    private Action attackSkill2;
    private Action attackSkill3;
    private Action attackSkill4;
    private Action defenseSkill1;
    private Action defenseSkill2;
    private Action defenseSkill3;
    private Action defenseSkill4;
    private Action specialSkill1;
    private Action specialSkill2;
    private Action specialSkill3;
    private Action specialSkill4;
    public void ActionReset()
    {
        //20 / 100 * Player.Instance.UnitStat.MaxHp디펜스 실수 값 넣어야함
        attackSkill1 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + Player.Instance.UnitStat.AttackPowerUp); UI.Instance.SkillName("오브젝트 어택"); Attack++; };
        attackSkill2 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 1); UI.Instance.SkillName("클래스 어택"); Attack++; };
        attackSkill3 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("인스턴스"); Attack++; };
        attackSkill4 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 3); UI.Instance.SkillName("선형탐색 어택"); Attack++;};
        defenseSkill1 = () => { Player.Instance.ChangeDeefense(1); UI.Instance.SkillName("알고리즘 방어"); Defense++; };
        defenseSkill2 = () => { Player.Instance.ChangeDeefense(2); UI.Instance.SkillName("콜라이더 방어"); Defense++; };
        defenseSkill3 = () => { Player.Instance.ChangeDeefense(3); UI.Instance.SkillName("메쉬콜라이더 방어"); Defense++; };
        defenseSkill4 = () => { Player.Instance.ChangeDeefense(4); UI.Instance.SkillName("폴리곤콜라이더 방어"); Defense++; };
        specialSkill1 = () => { Player.Instance.ChangeAttackPowerUp(1); UI.Instance.SkillName("게임엔진기초"); Defense++; };
        specialSkill2 = () => { Player.Instance.ChangeHp(1); UI.Instance.SkillName("게임프로그래밍"); Special++; };
        specialSkill3 = () => { Player.Instance.ChangeDeefense(80 / 100 * Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("자료구조"); Special++; };
        specialSkill4 = () => { Player.Instance.ChangeAttackPowerUp(1); Player.Instance.ChangeHp(1); UI.Instance.SkillName("응프"); Special++; };
        Actions = new Dictionary<Sprite, Action>()
        {
            {Item.Item[0],attackSkill1},
            {Item.Item[1],attackSkill2},
            {Item.Item[2],attackSkill3},
            {Item.Item[3],attackSkill4},
            {Item.Item[4],defenseSkill1},
            {Item.Item[5],defenseSkill2},
            {Item.Item[6],defenseSkill3},
            {Item.Item[7],defenseSkill4},
            {Item.Item[8],specialSkill1},
            {Item.Item[9],specialSkill2},
            {Item.Item[10],specialSkill3},
            {Item.Item[11],specialSkill4},
        };
    }

    #region Obsever
    public void Add(I_Obsever obsever, int index)
    {
        PlayerObsevers.Add(obsever);
    }
    public void Delete(I_Obsever obsever, int index)
    {
        PlayerObsevers.Remove(obsever);
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

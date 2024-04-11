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
        attackSkill1 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + Player.Instance.UnitStat.AttackPowerUp); UI.Instance.SkillName("일반공격"); };
        attackSkill2 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 1); UI.Instance.SkillName("강한공격"); };
        attackSkill3 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("죽음공격"); };
        attackSkill4 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 3); UI.Instance.SkillName("아주강한공격"); };
        defenseSkill1 = () => { Player.Instance.ChangeDeefense(1); UI.Instance.SkillName("방어"); ; };
        defenseSkill2 = () => { Player.Instance.ChangeDeefense(2); UI.Instance.SkillName("방방어"); ; };
        defenseSkill3 = () => { Player.Instance.ChangeDeefense(3); UI.Instance.SkillName("방방방어"); ; };
        defenseSkill4 = () => { Player.Instance.ChangeDeefense(4); UI.Instance.SkillName("방방방방어"); ; };
        specialSkill1 = () => { Player.Instance.ChangeAttackPowerUp(1); UI.Instance.SkillName("파워업"); ; };
        specialSkill2 = () => { Player.Instance.ChangeHp(1); UI.Instance.SkillName("생명력업"); };
        specialSkill3 = () => { Player.Instance.ChangeDeefense(8); UI.Instance.SkillName("방어력업"); };
        specialSkill4 = () => { Player.Instance.ChangeAttackPowerUp(1); Player.Instance.ChangeHp(1); UI.Instance.SkillName("종합선물"); };
        Actions = new Dictionary<Sprite, Action>()
        {
            {Item.Items[0, 0],attackSkill1},
            {Item.Items[0, 1],attackSkill2},
            {Item.Items[0, 2],attackSkill3},
            {Item.Items[0, 3],attackSkill4},
            {Item.Items[1, 0],defenseSkill1},
            {Item.Items[1, 1],defenseSkill2},
            {Item.Items[1, 2],defenseSkill3},
            {Item.Items[1, 3],defenseSkill4},
            {Item.Items[2, 0],specialSkill1},
            {Item.Items[2, 1],specialSkill2},
            {Item.Items[2, 2],specialSkill3},
            {Item.Items[2, 3],specialSkill4},
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

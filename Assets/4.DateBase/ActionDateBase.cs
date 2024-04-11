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
        //20 / 100 * Player.Instance.UnitStat.MaxHp���潺 �Ǽ� �� �־����
        attackSkill1 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + Player.Instance.UnitStat.AttackPowerUp); UI.Instance.SkillName("������Ʈ ����"); };
        attackSkill2 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 1); UI.Instance.SkillName("Ŭ���� ����"); };
        attackSkill3 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("�ν��Ͻ�"); };
        attackSkill4 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 3); UI.Instance.SkillName("����Ž�� ����"); };
        defenseSkill1 = () => { Player.Instance.ChangeDeefense(1); UI.Instance.SkillName("�˰��� ���"); ; };
        defenseSkill2 = () => { Player.Instance.ChangeDeefense(2); UI.Instance.SkillName("�ݶ��̴� ���"); ; };
        defenseSkill3 = () => { Player.Instance.ChangeDeefense(3); UI.Instance.SkillName("�޽��ݶ��̴� ���"); ; };
        defenseSkill4 = () => { Player.Instance.ChangeDeefense(4); UI.Instance.SkillName("�������ݶ��̴� ���"); ; };
        specialSkill1 = () => { Player.Instance.ChangeAttackPowerUp(1); UI.Instance.SkillName("���ӿ�������"); ; };
        specialSkill2 = () => { Player.Instance.ChangeHp(1); UI.Instance.SkillName("�������α׷���"); };
        specialSkill3 = () => { Player.Instance.ChangeDeefense(8); UI.Instance.SkillName("�ڷᱸ��"); };
        specialSkill4 = () => { Player.Instance.ChangeAttackPowerUp(1); Player.Instance.ChangeHp(1); UI.Instance.SkillName("����"); };
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

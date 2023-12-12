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
        attackSkill1 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + Player.Instance.UnitStat.AttackPowerUp); UI.Instance.SkillName("������Ʈ ����"); Attack++; };
        attackSkill2 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 1); UI.Instance.SkillName("Ŭ���� ����"); Attack++; };
        attackSkill3 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("�ν��Ͻ�"); Attack++; };
        attackSkill4 = () => { Player.Instance.Anim.SetBool("Attack", true); NotifyObserver<int>(PlayerObsevers, Player.Instance.UnitStat.AttackPower + 3); UI.Instance.SkillName("����Ž�� ����"); Attack++;};
        defenseSkill1 = () => { Player.Instance.ChangeDeefense(1); UI.Instance.SkillName("�˰��� ���"); Defense++; };
        defenseSkill2 = () => { Player.Instance.ChangeDeefense(2); UI.Instance.SkillName("�ݶ��̴� ���"); Defense++; };
        defenseSkill3 = () => { Player.Instance.ChangeDeefense(3); UI.Instance.SkillName("�޽��ݶ��̴� ���"); Defense++; };
        defenseSkill4 = () => { Player.Instance.ChangeDeefense(4); UI.Instance.SkillName("�������ݶ��̴� ���"); Defense++; };
        specialSkill1 = () => { Player.Instance.ChangeAttackPowerUp(1); UI.Instance.SkillName("���ӿ�������"); Defense++; };
        specialSkill2 = () => { Player.Instance.ChangeHp(1); UI.Instance.SkillName("�������α׷���"); Special++; };
        specialSkill3 = () => { Player.Instance.ChangeDeefense(80 / 100 * Player.Instance.UnitStat.MaxHp); UI.Instance.SkillName("�ڷᱸ��"); Special++; };
        specialSkill4 = () => { Player.Instance.ChangeAttackPowerUp(1); Player.Instance.ChangeHp(1); UI.Instance.SkillName("����"); Special++; };
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

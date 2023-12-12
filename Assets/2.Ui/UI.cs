using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class UI : SingleTone<UI>, I_ObseverManager
{
    [SerializeField] private Button turnEndBtn;
    [SerializeField] private Button turnStrBtn;
    [SerializeField] private Image skillNameBack;
    [SerializeField] private Text skillNameText;
    private List<I_Obsever> endbuttonObsevers = new List<I_Obsever>();
    private List<I_Obsever> startbuttonObsevers = new List<I_Obsever>();
    Dictionary<int, List<I_Obsever>> ObseverSet;


    public override void Awake()
    {
        base.Awake();
        ObseverSet = new Dictionary<int, List<I_Obsever>>
        {
            {1,endbuttonObsevers},
            {2,startbuttonObsevers}
        };
    }
    private void Start()
    {
        clickGather();
        skillNameBack.gameObject.SetActive(false);
        StartCoroutine(SkillNameOff());
    }

    private void clickGather()
    {
        turnEndBtn.onClick.AddListener(() => NotifyObserver(endbuttonObsevers, GameSystem.Instance.Condition.Repeat.TurnEnd));
        turnStrBtn.onClick.AddListener(() => NotifyObserver(startbuttonObsevers, GameSystem.Instance.Condition.Repeat.TurnSt));
    }

    
    public void SkillName(string skill)
    {
        skillNameBack.gameObject.SetActive(true);
        skillNameText.text = skill;


    }
    IEnumerator SkillNameOff()
    {
        skillNameBack.gameObject.TryGetComponent(out Animator ani);
        while (true)
        {
            yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
            skillNameBack.gameObject.SetActive(false);
        }
    }
    public void Add(I_Obsever obsever, int index)
    {
        ObseverSet[index].Add(obsever);
    }
    public void Delete(I_Obsever obsever, int index)
    {
        ObseverSet[index].Remove(obsever);
    }
    public void NotifyObserver<T>(List<I_Obsever> obsevers, T value)
    {
        if (value.Equals(true))
        {
            foreach (I_Obsever obsever in obsevers)
            {
                obsever.Refresh<int>(1);
            }
        }
    }
}

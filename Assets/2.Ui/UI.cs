using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UI : SingleTone<UI>, I_ObseverManager
{
    [SerializeField] private Button turnEndBtn;
    [SerializeField] private Button turnStrBtn;
    //[SerializeField] private ItemDateBase itemDate;
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
    }

    private void clickGather()
    {
        turnEndBtn.onClick.AddListener(() => NotifyObserver(endbuttonObsevers));
        turnStrBtn.onClick.AddListener(() => NotifyObserver(startbuttonObsevers));
    }


    public void Add(I_Obsever obsever,int index)
    {
        ObseverSet[index].Add(obsever);
    }
    public void Delete(I_Obsever obsever, int index)
    {
        ObseverSet[index].Remove(obsever);
    }
    public void NotifyObserver(List<I_Obsever> obsevers)
    {
        foreach (I_Obsever obsever in obsevers)
        {
            obsever.Refresh();
        }
    }
}

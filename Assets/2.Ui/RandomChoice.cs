using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomChoice : SingleTone<RandomChoice>, I_Obsever
{
    [SerializeField] private ItemDateBase Item;
    [SerializeField] private ConditionDateBase Condition;
    public Image[] Slot = new Image[4]; //고쳐야함
    private bool Check = true;
    void Start()
    {
        StartCoroutine(RandonCard());
    }
    IEnumerator RandonCard()
    {
        while (true)
        {
            yield return new WaitUntil(() => Condition.Repeat.TurnSt && Check);
            foreach (Image item in Slot)
            {
                item.sprite = Item.Item[UnityEngine.Random.Range(0, 12)];
            }
            Check = false;
        }
    }
    public void Refresh<T>(T value)
    {
        Check = Convert.ToBoolean(value);
    }
}

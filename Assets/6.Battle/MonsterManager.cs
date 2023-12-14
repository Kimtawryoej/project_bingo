using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterManager : SingleTone<MonsterManager>
{
    [SerializeField] private GameObject[] monsterCount = new GameObject[3];
    public GameObject[] MonsterCount { get { return monsterCount; } }
    //private int index = 0;
    public int Index { get; set; } = 0;
    [SerializeField] private GameObject targetPos;

    private void Start()
    {
        //StartCoroutine(NextMonster());
        for (int i = 1; i < MonsterCount.Length; i++)
        {
            monsterCount[i].gameObject.SetActive(false);
        }
    }
    public void  NextMonster()
    {
        if (!monsterCount[Index].gameObject.activeSelf)
        {
            Index++;
            monsterCount[Index].SetActive(true);
            monsterCount[Index].transform.position = targetPos.transform.position;
        }
        //while (monsterCount[Index].transform.position.x < targetPos.transform.position.x)
        //{

        //}
    }
}

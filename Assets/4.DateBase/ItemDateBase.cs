using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDateBase", menuName = "ItemDateBase", order = 1)]
public class ItemDateBase : ScriptableObject
{
    [SerializeField] private Sprite[] item = new Sprite[5];
    public Sprite[] Item { get { return item; } set => value = item; }
}

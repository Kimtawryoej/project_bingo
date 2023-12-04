using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDateBase", menuName = "ItemDateBaseDateBase", order = 1)]
public class ItemDateBase : ScriptableObject
{
    [SerializeField] private Sprite[] slot = new Sprite[5];
}

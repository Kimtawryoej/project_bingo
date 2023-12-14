using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDateBase", menuName = "ItemDateBase", order = 1)]
public class ItemDateBase : ScriptableObject
{
    [SerializeField] private Sprite[] item = new Sprite[12];
    //public Sprite[] Item { get { return item; } }
    public Sprite[,] Items = new Sprite[3, 4];
    public void ItemsSet()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Items[i, j] = item[(j + (4 * i))];    
            }
        }
    }
}

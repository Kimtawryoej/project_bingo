using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image[] slot = new Image[16];
    public LinkedList<Image> SlotItem { get; set; } = new LinkedList<Image>();
    public Queue<Image> OneSaveItem {  get; set; } = new Queue<Image> ();

    void Update()
    {
        
    }


}

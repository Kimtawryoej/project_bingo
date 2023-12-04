using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image[] slot = new Image[16];
    
    public LinkedList<Image> SlotItem { get; set; } = new LinkedList<Image>();
    public Queue<Image> OneSaveItem { get; set; } = new Queue<Image>();
    private GameObject clickedObject;

    private void Start()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject;
    }


}

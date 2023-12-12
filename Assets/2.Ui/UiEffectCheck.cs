using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiEffectCheck : MonoBehaviour, IPointerClickHandler, Hitcheck
{
    private bool hitcheck = false;
    public GameObject clickedObject;
    void Start()
    {
        StartCoroutine(HiEffect());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject;
        hitcheck = true;

    }
    public IEnumerator HiEffect()
    {
        while (true)
        {
            yield return new WaitUntil(() => hitcheck);
            yield return Effect.Instance.EffectsSys(clickedObject.transform.position, 2);
            hitcheck = false;
        }
    }

}

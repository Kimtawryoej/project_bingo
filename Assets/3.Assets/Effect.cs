using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : SingleTone<Effect>
{
    [SerializeField] private GameObject[] effect = new GameObject[3];
    public IEnumerator EffectsSys(Vector3 Pos, int Index)
    {
        effect[Index].SetActive(true);
        effect[Index].TryGetComponent(out Animator ani);
        effect[Index].transform.position = Pos + new Vector3(0,0.5f, 0);
        yield return new WaitUntil(() => ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        effect[Index].SetActive(false);
    }
}

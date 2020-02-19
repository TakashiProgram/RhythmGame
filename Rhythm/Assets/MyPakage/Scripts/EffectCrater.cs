using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCrater : MonoBehaviour {

    [SerializeField]
    private GameObject m_EffectCreate;

    public void EffectCreate(Vector3 pos)
    {
        Instantiate(m_EffectCreate, pos, Quaternion.identity);
    }
}

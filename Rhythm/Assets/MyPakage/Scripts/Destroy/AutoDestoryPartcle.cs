using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestoryPartcle : MonoBehaviour {
    [SerializeField]
    private ParticleSystem m_ParticleSystem;

    void Start () {
        Destroy(gameObject, (float)m_ParticleSystem.main.duration);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreater : MonoBehaviour {
    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private Map m_Map;
    [SerializeField]
    private float m_Time;
	void Start () {
        Invoke("StateSound", m_Time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void StateSound()
    {
        m_AudioSource.Play();
        m_Map.enabled = true;
    }
}

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
	
    private void StateSound()
    {
        m_AudioSource.Play();
        m_Map.enabled = true;
    }
}

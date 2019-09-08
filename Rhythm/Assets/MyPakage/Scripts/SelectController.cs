using UnityEngine;

public class SelectController : MonoBehaviour {

    [SerializeField]
    private SoundSava m_SoundSava;

    [SerializeField]
    private SetSound m_SetSound;

    [SerializeField]
    private AudioSource m_AudioSource;

    private bool m_IsFirst = true;

    private void OnTriggerEnter(Collider other)
    {
        if (true == m_IsFirst)
        {
            m_IsFirst = false;
            return;
        }
        m_AudioSource.Play();

        m_SetSound.SetSoundIndex(int.Parse(other.gameObject.name));
        m_SoundSava.SetSoundCount(int.Parse(other.gameObject.name));
        m_SoundSava.SetSoundName(other.gameObject.transform.parent.gameObject.name);
    }
}

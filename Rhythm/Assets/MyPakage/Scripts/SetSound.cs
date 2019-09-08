using UnityEngine;
using UnityEngine.UI;

public class SetSound : MonoBehaviour {

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private AudioClip[] m_AudioClip;

    private int m_SoundIndex;

    [SerializeField]
    private Sprite[] m_SoundSprite;

    [SerializeField]
    private Image m_SoundImage;
	
    public void SwitchSound()
    {
        m_AudioSource.clip = m_AudioClip[m_SoundIndex];
        m_SoundImage.sprite = m_SoundSprite[m_SoundIndex];

        m_AudioSource.Play();
    }

    public void SetSoundIndex(int index)
    {
        m_SoundIndex = index;
    }
}

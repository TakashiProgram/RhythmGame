using UnityEngine;

public class SoundList : MonoBehaviour {

    [SerializeField]
    private string[] m_SoundList;

    public string[] SetSoundList()
    {
        return m_SoundList;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour {

    [SerializeField]
    private string[] m_SoundList;

    public string[] SetSoundList()
    {
        return m_SoundList;
    }
}

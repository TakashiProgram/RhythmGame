﻿using UnityEngine;

public class SoundSava : MonoBehaviour {

    private int m_SoundCount = 0;

    private string m_SoundName = "";
	void Start () {
        DontDestroyOnLoad(this);
    }
    public void SetSoundCount(int sound_count)
    {
        m_SoundCount = sound_count;
    }

    public void SetSoundName(string name)
    {
        m_SoundName = name;
    }

    public int GetSoundCount()
    {
        return m_SoundCount;
    }

    public string GetSoundName()
    {
        return m_SoundName;
    }
}

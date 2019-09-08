using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    private enum Judgment
    {
        None,
        PERFECT,
        GREAT,
        MISS
    }

    private int m_ComboCount;

    [SerializeField]
    private Text m_JudgmentText;

    [SerializeField]
    private Text m_ComboText;
    [SerializeField]
    private ScoreManager m_ScoreManager;

    private const int m_PerfectScore = 100;

    private const int m_GreatScore = 50;

    private const int m_MissScore = 0;

    [SerializeField]
    private GameObject[] m_HitEffect;

    private Vector3 m_EffectPos;

    private int m_PerfectCount = 0;

    private int m_GreatCount = 0;

    private int m_MissCount = 0;

    private int m_ComboMax = 0;

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private AudioClip[] m_AudioClip;

    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (0<m_ComboCount)
        {
            m_ComboText.text = "Combo \n" + m_ComboCount;
        }
        else
        {
            m_ComboText.text = "";
        }
		
	}
    public void SetEffectPos(Vector3 pos)
    {
        m_EffectPos = pos;
    }
    public void SetComboCount(int count)
    {

        switch (count)
        {
            case (int)Judgment.PERFECT:
                m_JudgmentText.text = "PERFECT";
                m_ScoreManager.ScoreAdd(m_PerfectScore);
                
                Instantiate(m_HitEffect[0], m_EffectPos, Quaternion.identity);
                m_ComboCount++;
                m_PerfectCount++;
                m_ScoreManager.PerfectAdd(m_PerfectCount);
                m_AudioSource.clip = m_AudioClip[0];
                Instantiate(m_AudioSource);
                break;

            case (int)Judgment.GREAT:
                m_JudgmentText.text = "GREAT";
                m_ScoreManager.ScoreAdd(m_GreatScore);
               
                Instantiate(m_HitEffect[1], m_EffectPos, Quaternion.identity);
                m_ComboCount++;
                m_GreatCount++;
                m_ScoreManager.GreatAdd(m_GreatCount);
                m_AudioSource.clip = m_AudioClip[1];
                Instantiate(m_AudioSource);
                break;

            case (int)Judgment.MISS:
                m_JudgmentText.text = "MISS";
                m_ScoreManager.ScoreAdd(m_MissScore);
               

                m_ComboCount = 0;
                m_MissCount++;
                m_ScoreManager.MissAdd(m_MissCount);
                break;
        }
        if (m_ComboMax <= m_ComboCount)
        {
            m_ComboMax = m_ComboCount;
        }
    }
}

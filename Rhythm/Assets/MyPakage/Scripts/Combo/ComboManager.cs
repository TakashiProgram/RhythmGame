﻿using System.Collections;
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

    private const int m_PerfectCount = 100;

    private const int m_GreatCount = 50;

    private const int m_MissCount = 0;
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

    public void SetComboCount(int count)
    {

        switch (count)
        {
            case (int)Judgment.PERFECT:
                m_JudgmentText.text = "PERFECT";
                m_ScoreManager.ScoreAdd(m_PerfectCount);
                m_ComboCount++;
                break;

            case (int)Judgment.GREAT:
                m_JudgmentText.text = "GREAT";
                m_ScoreManager.ScoreAdd(m_GreatCount);
                m_ComboCount++;
                break;

            case (int)Judgment.MISS:
                m_JudgmentText.text = "MISS";
                m_ScoreManager.ScoreAdd(m_MissCount);
                m_ComboCount = 0;
                break;
        }
       

        //if (((int)Judgment.PEFECT == count) || ((int)Judgment.GREAT == count))
        //{
        //    m_ComboCount++;
        //}
        //else
        //{
        //    m_ComboCount = 0;
        //}
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int m_OverallScore;

    private int m_PerfectCount;
    private int m_GreatCount;
    private int m_MissCount;
    void Start () {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void ScoreAdd(int score)
    {
        m_OverallScore += score;
    }

    public void PerfectAdd(int perfect)
    {
        m_PerfectCount = perfect;
    }

    public void GreatAdd(int great)
    {
        m_GreatCount = great;
    }

    public void MissAdd(int miss)
    {
        m_MissCount = miss;
    }

    public int GetScore()
    {
        return m_OverallScore;
    }

    public int GetPerfect()
    {
        return m_PerfectCount;
    }

    public int GetGreat()
    {
        return m_GreatCount;
    }

    public int GetMiss()
    {
        return m_MissCount;
    }

}

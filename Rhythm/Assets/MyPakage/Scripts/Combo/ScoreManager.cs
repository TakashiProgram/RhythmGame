using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int m_OverallScore;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ScoreAdd(int score)
    {
        m_OverallScore += score;
    }
}

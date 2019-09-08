using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContrlloer : MonoBehaviour {

    [SerializeField]
    private Text[] m_Score;
    [SerializeField]
    private int[] m_AllScore;
	void Start () {
        GameObject obj = GameObject.Find("ScoreManager");

        GameObject clear_obj = GameObject.Find("SoundSava");

        ScoreManager score_manager = obj.GetComponent<ScoreManager>();

        string clear_sound_name = clear_obj.GetComponent<SoundSava>().GetSoundName();
        if (clear_sound_name == "")
        {
            clear_sound_name = "ロロナ";
        }
        Debug.Log(clear_sound_name);
        PlayerPrefs.SetString(clear_sound_name, clear_sound_name);

        m_Score[0].text = score_manager.GetScore().ToString();
        m_Score[1].text = score_manager.GetPerfect().ToString();
        m_Score[2].text = score_manager.GetGreat().ToString();
        m_Score[3].text = score_manager.GetMiss().ToString();
        Destroy(obj);
        Destroy(clear_obj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int index , int score)
    {
        m_AllScore[index] = score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public enum SceneName
    {
        Titel,
        Select,
        Game,
        Result
    }

    [SerializeField]
    private FadeImage m_FadeImage;

    private bool m_IsChangeScene = false;
    [SerializeField]
    private SceneName m_SceneName;

    [SerializeField]
    private Fade m_Fade;
	void Start () {
        
	}
	
	void Update () {
       
        float range = m_FadeImage.SetRange();
        
        if (true == m_IsChangeScene)
        {
            if (range >= 1)
            {
                SceneManager.LoadScene(m_SceneName.ToString());
            }
        }
	}
    public void ChangeScene()
    {
        m_IsChangeScene=true;
        m_Fade.FadeIn(1.0f);

    }
}

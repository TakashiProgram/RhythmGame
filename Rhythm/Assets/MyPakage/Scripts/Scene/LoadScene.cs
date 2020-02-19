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

    [SerializeField]
    private TouchInputer m_TouchInputer;

    private GameObject m_TouchObj;
    
    void Update () {
        if (null == m_TouchObj)
        {
            m_TouchObj = m_TouchInputer.ObjectTapDown();
            return;
        }
        if (m_TouchObj != this.gameObject) return;
        
        float range = m_FadeImage.SetRange();
        
        if (true == m_IsChangeScene)
        {
            if (range >= 1)
            {
                SceneManager.LoadScene(m_SceneName.ToString());
            }
        }
        else
        {
            ChangeScene();
        }
	}
    public void ChangeScene()
    {
        m_IsChangeScene=true;
        m_Fade.FadeIn(1.0f);
    }
}

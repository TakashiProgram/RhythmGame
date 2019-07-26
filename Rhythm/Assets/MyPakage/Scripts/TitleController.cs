using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
    [SerializeField]
    private Image m_SongTitle;
    
    private bool m_IsTransparent;

    private float m_Color;

    [SerializeField]
    private GameObject[] m_StateNode;

    private bool test = false;

    [SerializeField]
    private AudioSource m_AudioSource;

    private bool m_IsSoundPlay = false;

    [SerializeField]
    private LoadScene m_LoadScene;

    void Start () {
        StartCoroutine("SongTitle");
	}
	
	// Update is called once per frame
	void Update () {
        if (true == m_IsTransparent)
        {
            m_SongTitle.color = new Color(0, 0, 0, m_Color);
            m_Color -= Time.deltaTime;
            if (m_Color <0 && test==false)
            {
                m_SongTitle.enabled = false;
                // Destroy(this.gameObject.GetComponent<TitleController>());
                for (int i = 0; i < m_StateNode.Length; i++)
                {
                    m_StateNode[i].SetActive(true);
                }
                test = true;
                Invoke("SoundRegeneration",5.0f);
            } 
        }
        if ((true == m_IsSoundPlay) && (!m_AudioSource.isPlaying))
        {
            m_IsSoundPlay = false;
            Invoke("GameClear", 2.0f);
        }

    }
    private void SoundRegeneration()
    {
        m_IsSoundPlay = true;
        m_AudioSource.Play();
    }

    private IEnumerator SongTitle()
    {
        yield return new WaitForSeconds(1.0f);
        m_SongTitle.enabled = true;

        yield return new WaitForSeconds(3.0f);
        m_IsTransparent = true;

    }

    private void GameClear()
    {
        m_LoadScene.ChangeScene();
    }
}

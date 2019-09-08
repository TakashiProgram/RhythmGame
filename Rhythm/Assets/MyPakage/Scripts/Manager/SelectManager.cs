using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour {

    [SerializeField]
    private RayCast m_RayCast;

    [SerializeField]
    private EffectManager m_EffectManager;

    private GameObject m_TapObject;

    [SerializeField]
    private GameObject m_SelectUI;

    [SerializeField]
    private ITweenManager m_ITweenManager;

    [SerializeField]
    private FixedScrollRect m_ScrollObject;

    [SerializeField]
    private LoadScene m_LoadScene;

    [SerializeField]
    private SetSound m_SetSound;

    private bool m_IsSound = true;

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private AudioClip[] m_AudioClip;
   
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            m_TapObject = m_RayCast.RayerHitObject();

            ColorController color_controller = m_TapObject.GetComponent<ColorController>();
            
            if (color_controller != null)
            {
                color_controller.SetChangeColor();
            }

            if (m_TapObject.tag == "Select")
            {
                m_ITweenManager.ITweenScale(m_SelectUI,4);
                m_ScrollObject.enabled = false;
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[0];
                m_AudioSource.Play();
            }

            if (m_TapObject.tag == "No")
            {
                m_ITweenManager.ITweenScale(m_SelectUI, 0);
                m_ScrollObject.enabled = true;
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[1];
                m_AudioSource.Play();
            }

            if (m_TapObject.tag == "Yes")
            {
                m_LoadScene.ChangeScene();
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[2];
                m_AudioSource.Play();
            }
           
            Vector3 tap = Input.mousePosition;
            tap.z = 8;
            m_EffectManager.TapEffect(Camera.main.ScreenToWorldPoint(tap));
        }
        if (Input.GetMouseButtonUp(0))
        {

            if (false == m_IsSound)
            {
                m_IsSound = true;
                return;
            }
            m_SetSound.SwitchSound();

            ColorController color_controller = m_TapObject.GetComponent<ColorController>();

            if (color_controller != null)
            {
                color_controller.SetReturnColor();
            } 
        }
    }
}

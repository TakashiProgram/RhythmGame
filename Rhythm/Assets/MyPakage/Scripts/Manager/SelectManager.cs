using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour {

    [SerializeField]
    private RaySkipper m_RaySkipper;

    [SerializeField]
    private EffectCrater m_EffectCrater;

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

    [SerializeField]
    private TouchInputer m_TouchInputer;


    void Update () {

        var tap_down = m_TouchInputer.ObjectTapDown();

        if (null != tap_down)
        {
            m_TapObject = tap_down;
            ColorController color_controller = tap_down.GetComponent<ColorController>();

            if (color_controller != null)
            {
                color_controller.SetChangeColor();
            }

            if (tap_down.tag == "Select")
            {
                m_ITweenManager.ITweenScale(m_SelectUI, 4);
                m_ScrollObject.enabled = false;
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[0];
                m_AudioSource.Play();
            }

            if (tap_down.tag == "No")
            {
                m_ITweenManager.ITweenScale(m_SelectUI, 0);
                m_ScrollObject.enabled = true;
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[1];
                m_AudioSource.Play();
            }

            if (tap_down.tag == "Yes")
            {
                m_LoadScene.ChangeScene();
                m_IsSound = false;
                m_AudioSource.clip = m_AudioClip[2];
                m_AudioSource.Play();
            }

           
        }
        var tap_up = m_TouchInputer.ObjectTapUp();
       
        if (null != tap_up)
        {
            //if (false == m_IsSound)
            //{
            //    m_IsSound = true;
            //    return;
            //}
            m_SetSound.SwitchSound();
            Debug.Log(tap_up);
            ColorController color_controller = m_TapObject.GetComponent<ColorController>();

            if (color_controller != null)
            {
                color_controller.SetReturnColor();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputer : MonoBehaviour
{
    [SerializeField]
    private RaySkipper m_RaySkipper;

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private EffectCrater m_EffectCreater;

    private readonly int DEPTH = 8;

    void Update()
    {
        var tap_down = ObjectTapDown();

        if (null != tap_down)
        {
            m_AudioSource.Play();

            Vector3 tap_pos = m_RaySkipper.MousePos();
            tap_pos.z = DEPTH;
            m_EffectCreater.EffectCreate(Camera.main.ScreenToWorldPoint(tap_pos));
        }
    }
    public GameObject ObjectTap()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject hit = m_RaySkipper.HitObject();
            if (null != hit)

                return hit;
        }
        return null;
    }

    public GameObject ObjectTapDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hit = m_RaySkipper.HitObject();
            if (null != hit)

                return hit;
        }
        return null;
    }

    public GameObject ObjectTapUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject hit = m_RaySkipper.HitObject();
            if (null != hit)

                return hit;
        }
        return null;
    }
}

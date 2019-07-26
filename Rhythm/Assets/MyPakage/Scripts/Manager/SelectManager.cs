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
	void Start () {
		
	}
	
	// Update is called once per frame
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
                
            }

            if (m_TapObject.tag == "No")
            {
                m_ITweenManager.ITweenScale(m_SelectUI, 0);
                m_ScrollObject.enabled = true;
            }

            if (m_TapObject.tag == "Yes")
            {
                m_LoadScene.ChangeScene();
            }
           


            Vector3 tap = Input.mousePosition;
            tap.z = 8;
            m_EffectManager.TapEffect(Camera.main.ScreenToWorldPoint(tap));
        }
        if (Input.GetMouseButtonUp(0))
        {
            ColorController color_controller = m_TapObject.GetComponent<ColorController>();

            if (color_controller != null)
            {
                color_controller.SetReturnColor();
            }
                
            
        }
        
    }
}

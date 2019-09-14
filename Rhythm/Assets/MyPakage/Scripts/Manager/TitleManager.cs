using UnityEngine;

public class TitleManager : MonoBehaviour {
    [SerializeField]
    private RayCast m_RayCast;

    [SerializeField]
    private EffectManager m_EffectManager;

    [SerializeField]
    private AudioSource m_AudioSource;

    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = m_RayCast.RayerHitObject();

            if (null == obj)
            {
                return;
            }
            
            LoadScene load_scene = obj.GetComponent<LoadScene>();
            if (null != load_scene)
            { 
                m_AudioSource.Play();
                load_scene.ChangeScene();
            }

            Vector3 tap_pos = Input.mousePosition;
            tap_pos.z = 8;
            m_EffectManager.TapEffect(Camera.main.ScreenToWorldPoint(tap_pos));
        }
    }
}

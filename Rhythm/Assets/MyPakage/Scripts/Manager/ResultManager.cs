using UnityEngine;

public class ResultManager : MonoBehaviour {
    [SerializeField]
    private RayCast m_RayCast;

    [SerializeField]
    private EffectManager m_EffectManager;

    [SerializeField]
    private AudioSource m_AudioSource;
    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = m_RayCast.RayerHitObject();
           
            LoadScene load_scene = obj.GetComponent<LoadScene>();
            if (null != load_scene)
            {
                load_scene.ChangeScene();
                m_AudioSource.Play();
            }

            Vector3 tap = Input.mousePosition;
            tap.z = 8;
            m_EffectManager.TapEffect(Camera.main.ScreenToWorldPoint(tap));
        }
    }
}

using UnityEngine;

public class EffectManager : MonoBehaviour {

    [SerializeField]
    private GameObject m_TapEffect;
	
    public void TapEffect(Vector3 pos)
    {
        Instantiate(m_TapEffect, pos,Quaternion.identity);
    }
}

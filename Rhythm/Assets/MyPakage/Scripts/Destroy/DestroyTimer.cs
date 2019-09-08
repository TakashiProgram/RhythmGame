using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    [SerializeField]
    private float m_Timer = 1.0f;
	void Start () {
        StartCoroutine("DestroyTime");
    }
    private IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(m_Timer);
        Destroy(this.gameObject);
    }
   
}

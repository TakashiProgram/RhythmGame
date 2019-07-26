using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    [SerializeField]
    private float m_Timer = 1.0f;
	void Start () {
        StartCoroutine("DestroyTime");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(m_Timer);
        Destroy(this.gameObject);
    }
   
}

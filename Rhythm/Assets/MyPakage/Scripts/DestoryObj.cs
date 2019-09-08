using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour {

    [SerializeField]
    private float m_DesCount;
	void Start () {
        Destroy(this.gameObject, m_DesCount);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}

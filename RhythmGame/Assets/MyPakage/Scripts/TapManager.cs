using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour {
    [SerializeField]
    private RayCast m_Raycast;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)/* || Input.GetKeyDown(KeyCode.A)*/)
        {
            GameObject obj = m_Raycast.RayerHitObject();
            

            if (obj.gameObject.tag == "Tap")
            {
                //当たっているラインに値を入れる
            }
        }
	}
}

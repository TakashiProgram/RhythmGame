using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    [SerializeField]
    private GameObject test1;

    [SerializeField]
    private GameObject test2;

    [SerializeField]
    private LineRenderer testline;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        testline.SetPosition(0, test1.transform.position);
        testline.SetPosition(0, test2.transform.position);
    }
}

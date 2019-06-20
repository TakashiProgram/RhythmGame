
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMove : MonoBehaviour {

    [SerializeField]
    private float m_MoveTime;

    [SerializeField]
    public Transform m_Destination;

    private new Transform transform;

    private float m_Time = 0;

    private Vector3 m_StartPos;
    private Vector3 m_DestinationPos;

	void Start () {
        transform = GetComponent<Transform>();

       // m_DestinationPos = m_Destination.position;
        m_StartPos = this.transform.position;

    }
	

	void Update () {
        float time = m_Time / m_MoveTime;
        
        transform.position = Vector3.Lerp(m_StartPos, m_DestinationPos, time);

        m_Time += Time.deltaTime;
        if (transform.position == m_DestinationPos)
        {
            Destroy(gameObject);
        }
	}

    public void SetDestinationPos(Vector3 pos)
    {
        m_DestinationPos = pos;
    }
}

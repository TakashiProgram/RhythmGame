using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    private GameObject m_StateLine;
    private GameObject m_EndLine;
    [SerializeField]
    private LineRenderer m_LineRenderer;

    private Vector3 m_StateDesPos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (null !=m_StateLine)
        {
            m_StateDesPos = m_StateLine.transform.position;

            m_LineRenderer.SetPosition(0, m_StateLine.transform.position);
        }
        else
        {
            m_LineRenderer.SetPosition(0, m_StateDesPos);
        }
        
        
        if (null == m_EndLine)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_LineRenderer.SetPosition(1, m_EndLine.transform.position);
        }
        
    }


    public void SetLinePos(GameObject state, GameObject end)
    {
        m_StateLine = state;
        m_EndLine = end;
    }
   
}

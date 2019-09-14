using System.Collections.Generic;
using UnityEngine;

public class NodeCreater : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Node;

    [SerializeField]
    private Transform m_Destination;

    [SerializeField]
    private Transform m_LineDes;

    private GameObject m_LostPostion;

    private CSVReader m_CsvRender = new CSVReader();

    private List<List<string>> m_Map = new List<List<string>>();

    private int m_Line = 0;

    private float m_Time = 0;

    [SerializeField]
    private int m_Selector = 0;

    [SerializeField]
    private GameObject m_NodeParent;

    private GameObject m_LongNode;

    private string m_PlayeSoundName = "DS_First";

    [SerializeField]
    private GameObject m_LineController;

    private void Awake()
    {
        m_Map = m_CsvRender.ReadCSV(m_PlayeSoundName);
    }

    void Update()
    {
        m_Time += Time.deltaTime;

        if (0 == float.Parse(m_Map[m_Line][0]))
        {
            return;
        }
        else if (m_Time >= float.Parse(m_Map[m_Line][0]))
        {
            if (int.Parse(m_Map[m_Line][m_Selector]) == 1)
            {
                NodeCreate(m_Node[0]);
            }else if (int.Parse(m_Map[m_Line][m_Selector]) == 2)
            {
                if (null == m_LongNode)
                {
                    m_LongNode = NodeCreate(m_Node[1]);
                }
                else
                {
                    GameObject end_node = NodeCreate(m_Node[1]);
                    if (null == end_node)
                    {
                        return;
                    }
                    GameObject line = Instantiate(m_LineController);
                    if (null == line)
                    {
                        return;
                    }
                    line.GetComponent<LineController>().SetLinePos(m_LongNode,end_node);
                }
            }else if (int.Parse(m_Map[m_Line][m_Selector]) == 3)
            {
                NodeCreate(m_Node[2]);
            }else if (int.Parse(m_Map[m_Line][m_Selector]) == 4)
            {
                NodeCreate(m_Node[3]);
            }else if (int.Parse(m_Map[m_Line][m_Selector]) == 5)
            {
                NodeCreate(m_Node[0]);
            }
            m_Line++;
        }
    }
    private GameObject NodeCreate(GameObject obj)
    {
        GameObject node = Instantiate(obj, m_NodeParent.transform);
        
        node.transform.position = this.transform.position;
        node.GetComponent<NodeMove>().SetDestinationPos(m_Destination.position);
        return node;

    }

    public void SetSounaName(string name)
    {
        if (name == "")
        {
            name = "DS_First";
        }
        m_PlayeSoundName = name;
    }
}

using UnityEngine;

public class TapManager : MonoBehaviour
{

    [SerializeField]
    private RaySkipper m_RaySkipper;

    [SerializeField]
    private ComboManager m_ComboManager;

    private bool m_IsFlick = false;

    private float m_FlickTime = 0;

    private Vector3 m_StateMousePos;

    private GameObject m_FlickNode = null;

    private GameObject m_RayFlick = null;
    
    void Update()
    {

        if (true == m_IsFlick)
        {
            m_FlickTime += Time.deltaTime;
            if (m_FlickTime >= 0.5f)
            {
                m_FlickTime = 0;
                m_IsFlick = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = m_RaySkipper.HitObject();
            if (null == obj)
            {
                return;
            }
            if (obj.gameObject.tag == "Tap")
            {
                HitManager hit_manager = obj.GetComponent<HitManager>();
                if (null == hit_manager)
                {
                    return;
                }
                int count = hit_manager.GetJudgmentCount();

                GameObject node = hit_manager.GetNodeObject();
               
                if (null == node)
                {
                    return;
                }
                if (node.gameObject.tag == "Flick")
                {
                    m_StateMousePos = m_RaySkipper.MousePos();
                    m_FlickNode = node;
                    m_RayFlick = obj;
                    m_IsFlick = true;
                    return;
                }
               
                Destroy(node);
                m_ComboManager.SetEffectPos(hit_manager.GetPos());
                m_ComboManager.SetComboCount(count);

            }
        }

        if (Input.GetMouseButton(0))
        {
            if (true == m_IsFlick)
            {

                if (m_FlickTime >= 0.5f)
                {

                    Destroy(m_FlickNode);
                    return;
                }
                if (m_StateMousePos == m_RaySkipper.MousePos())
                {
                    return;
                }
                HitManager hit_manager = m_RayFlick.GetComponent<HitManager>();
                if (null == hit_manager)
                {
                    return;
                }
                int count = hit_manager.GetJudgmentCount();

                m_ComboManager.SetEffectPos(hit_manager.GetPos());
                m_ComboManager.SetComboCount(count);
                m_IsFlick = false;
                Destroy(m_FlickNode);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject obj = m_RaySkipper.HitObject();
            if (null == obj)
            {
                return;
            }

            if (obj.gameObject.tag == "Tap")
            {
                HitManager hit_manager = obj.GetComponent<HitManager>();
                int count = hit_manager.GetJudgmentCount();
              
                GameObject node = hit_manager.GetNodeObject();
                
                if (null == node)
                {
                    return;
                }
       
                if (node.gameObject.tag == "Long")
                {
                    Destroy(node);
                    m_ComboManager.SetEffectPos(hit_manager.GetPos());
                    m_ComboManager.SetComboCount(count);
                    return;
                }else if (node.gameObject.tag == "Flick")
                {
                    return;
                }
                Destroy(node);
                m_ComboManager.SetEffectPos(hit_manager.GetPos());
                m_ComboManager.SetComboCount(count);
            }
        }
    }

    private void FlickTime()
    {
        m_IsFlick = true;

    }
}

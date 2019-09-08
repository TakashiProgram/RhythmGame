using UnityEngine;
using TMPro;

public class TextHighlight : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;

    private float m_Num = Mathf.PI;
    
	void Update () {
        Material mat = m_TextMeshProUGUI.fontMaterial;

        mat.SetFloat("_OutlineWidth", Mathf.Abs(Mathf.Sin(m_Num)) * 2 / 5);
        m_Num += Time.deltaTime * 2;

    }
}

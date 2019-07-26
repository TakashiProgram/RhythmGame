using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetChangeColor()
    {
        m_SpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
       // m_SetColor = 
    }

    public void SetReturnColor()
    {
        m_SpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
       // m_SetColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}

using UnityEngine;

public class ColorController : MonoBehaviour {
    
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;
    
    public void SetChangeColor()
    {
        m_SpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SetReturnColor()
    {
        m_SpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}

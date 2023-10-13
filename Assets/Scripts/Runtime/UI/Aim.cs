using TMPro; 
using UnityEngine;

public class Aim : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI m_text;

    [Space(4)]

    [SerializeField]
    private CanvasGroup m_cnGroup;


    private const float MINIMUN_ALPHA_VALUE = 0.3f; 

    private void Awake()
    {
        m_text.enabled = false;
        m_cnGroup.alpha = MINIMUN_ALPHA_VALUE;
    }


    public void Activate()
    {
        m_text.enabled = true;
        m_cnGroup.alpha = 1.0f;
    }


    public void Deactivate()
    {
        switch(m_cnGroup.alpha)
        {
            case MINIMUN_ALPHA_VALUE:
                break;
            case 1.0f:
                m_text.enabled = false;
                m_cnGroup.alpha = 0.3f;
                break;
        }
    }
}

using TMPro; 
using UnityEngine;

public class Aim : MonoBehaviour
{

    #region Inspector

    [SerializeField]
    private TextMeshProUGUI m_text;

    [Space(4)]

    [SerializeField]
    private CanvasGroup m_cnGroup;

    #endregion

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


    /// <summary>
    /// Ultra fast checking for aim activation, if active then deactives
    /// </summary>
    public void Deactivate()
    {
        switch(m_cnGroup.alpha)
        {
            case MINIMUN_ALPHA_VALUE:
                break;
            // the alpha 1.0f is clue of activation
            case 1.0f:
                m_text.enabled = false;
                m_cnGroup.alpha = MINIMUN_ALPHA_VALUE;
                break;
        }
    }
}

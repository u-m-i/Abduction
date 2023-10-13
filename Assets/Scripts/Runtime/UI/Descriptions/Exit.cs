using UnityEngine;
using UnityEngine.UIElements;

namespace Nuruk.UI
{
    public class Exit : MonoBehaviour
    {
        [SerializeField]
        private UIDocument uxml;


        private void PrepareExit()
        {
            VisualElement root = uxml.rootVisualElement;

            Button button = root.Q<Button>("exit-button");

            button.clicked += () => {uxml.gameObject.SetActive(false);};
        }

    }
}
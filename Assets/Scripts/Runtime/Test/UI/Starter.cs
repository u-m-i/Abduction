using UnityEngine;
using UnityEngine.UIElements;

namespace Abduction
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private UIDocument document;

        private Button button;

        private void Start()
        {
            button = document.rootVisualElement.Q<Button>("Start-Button");

            // button.clicked += 
        }

    }
}
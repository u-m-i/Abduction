using UnityEngine;
using UnityEngine.UIElements;

namespace Nuruk.UI
{
    public class MovieDescription : MonoBehaviour
    {

        [SerializeField]
        private UIDocument uxml;


        private void OnEnable()
        {
            VisualElement root = uxml.rootVisualElement;

            Button button = root.Q<Button>("exit-button");

            button.clicked += () => {uxml.gameObject.SetActive(false);};
        }
    }
}

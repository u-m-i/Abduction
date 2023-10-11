using UnityEngine;
using UnityEngine.UIElements;

namespace Abduction
{
    public class Starter : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private UIDocument document;

        [Space(4)] 

        [SerializeField]
        [Tooltip("Must be a game object, not a uninstantiated prefab.")]
        private GameObject player;

        #endregion

        private Button button;


        private void Start()
        {
            button = document.rootVisualElement.Q<Button>("Start-Button");

            button.clicked += Begin;
        }

        private void Begin()
        {
            player.SetActive(true);
            document.gameObject.SetActive(false);
        }

    }
}
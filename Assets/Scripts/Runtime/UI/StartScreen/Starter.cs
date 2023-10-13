using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Abduction
{
    public class Curtain : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private CanvasGroup black;

        [Space(4)] 

        [SerializeField]
        private TextMeshProUGUI indication;

        [Space(4)]

        [SerializeField]
        private Button starter;

        #endregion

        private const string GOAL = "Explora para encontrar la nave";

        private const string HELP = "Camina con WASD y corre con SHIFT sostenido";


        private void Start()
        {
            // Reset all the courtain components
            indication.text = "";

            black.alpha = 0f;
            black.blocksRaycasts = false;

            starter.onClick.AddListener(PassScene);
        }


        private void PassScene()
        {
            // Add layer

            while(black.alpha < 1f)
            {
                black.alpha += 0.025f;
            }

            // Load the scene additively
            AsyncOperation aop = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

            // Wait until done
            while (!aop.isDone) ;


            StartCoroutine(Indication());
        }


        /// <summary>
        /// Prints a text with a stylish animation 
        /// </summary>
        /// <returns></returns>
        private IEnumerator Indication()
        {
            // Deactivate the curtain
            yield return null;
        }
    }
}
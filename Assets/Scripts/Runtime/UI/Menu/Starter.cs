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

        [Space(4)]

        [SerializeField]
        private GameObject initialView;

        #endregion

        private LoadSceneMode loadMode = LoadSceneMode.Additive;

        private float PACE = 0.08f;

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
            StartCoroutine(ShowIndications());
        }
 
        private IEnumerator ShowIndications()
        {
            black.blocksRaycasts = true;

            while(black.alpha < 1f)
            {
                black.alpha += 0.025f;
                yield return null;
            }


            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2, loadMode);

            while(!asyncOperation.isDone)
            {
                yield return null;
            }

            // Deactivate the background and the button
            Destroy(initialView);

            while(black.alpha > 0f)
            {
                black.alpha -= 0.025f;
                yield return null;
            }

            black.blocksRaycasts = false;
            
            yield return WriteText(GOAL);

            yield return new WaitForSeconds(2.3f);

            yield return WriteText(HELP);
        }


        /// <summary>
        /// Prints a text with a stylish animation 
        /// </summary>
        /// <returns></returns>
        private IEnumerator WriteText(string text)
        {
            indication.text = "";

            int index = 0;

            while(index < text.Length)
            {
                indication.text += text[index]; 
                ++index;

                yield return new WaitForSeconds(PACE);
            }
        }
    }
}
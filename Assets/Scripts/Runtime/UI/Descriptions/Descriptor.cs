using System;
using UnityEngine;
using System.Reflection;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Abduction.UI
{
    public class Descriptor : MonoBehaviour
    {
        [Header("UI")]

        [SerializeField]
        private UIDocument document;
        
        [Space(4)]

        [SerializeField]
        private string[] sources;

        [Space(4)]
        
        [Header("Player")]

        [SerializeField]
        private GameObject canvas;

        [Space(4)]

        [SerializeField]
        private FirstPersonMovement character;

        [Space(4)]

        [SerializeField]
        private FirstPersonLook look;

        [Space(4)]

        [SerializeField]
        private FirstPersonLook innerLook;


        [SerializeField]
        private Rigidbody body;

        private VisualElement Root => document.rootVisualElement;

        private PosterDetector posterDetector;

        private const char STOP_SYMBOL = '#';

        private const byte SPECIAL_LIMIT = 6;

        private const int MINIMUN_HEIGHT = 160;



        public void ShowCase(in PosterDetector posterDetector, int index)
        {

            this.posterDetector = posterDetector;

            body.angularVelocity =
            body.velocity = Vector3.zero;

            canvas.SetActive(false);

            character.speed = 0f;

            innerLook.enabled = 
            look.enabled = false;

            Movie movie = CreateMovieFromText(index);

            document.gameObject.SetActive(true);
            PrepareExit();
            SetDescription(movie);

            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }


        private void PrepareExit()
        {

            Button button = Root.Q<Button>("exit-button");

            button.clicked += () => 
            {
                character.speed = 5f;

                innerLook.enabled =
                look.enabled = true;

                canvas.SetActive(true);

                document.gameObject.SetActive(false);

                UnityEngine.Cursor.lockState = CursorLockMode.Locked;

                posterDetector.enabled = true;
            };
        }


        /// <summary>
        /// Sets the description of a movie in the UI
        /// </summary>
        private void SetDescription(in Movie movie)
        {
            FieldInfo[] fields = typeof(Movie).GetFields();

            int currentLabel = 0;

            foreach (FieldInfo field in fields)
            {

                if(field.Name == "Description" && movie.Description.Length < 200)
                {
                    Label site = Root.Q<Label>("Description");

                    site.style.height = MINIMUN_HEIGHT; 
                }


                if (field.Name == "ProjectionSites")
                {
                    List<string> projections = (List<string>) field.GetValue(movie);

                    Label site = Root.Q<Label>("Projections");

                    foreach (string projection in projections)
                    {
                        site.text += projection;

                        site.text += '\n';
                    }

                    break;
                }

                Label label = Root.Query<Label>().AtIndex(currentLabel);

                label.text = "";
                
                label.text += (string) field.GetValue(movie);

                currentLabel++;
            }
        }


        /// <summary>
        /// CHECKED
        /// </summary>
        /// <param name="index"></param>
        private Movie CreateMovieFromText(int index)
        {

            int currentField = 0;

            Movie movie = new Movie();

            string[] source = sources[index].Split(new[] { STOP_SYMBOL }, StringSplitOptions.RemoveEmptyEntries); 
            
            FieldInfo[] fields = typeof(Movie).GetFields(BindingFlags.Public | BindingFlags.Instance);


            List<string> accumulator = new List<string>();

            // Iterate over the whole source and when finding the pound symbol
            // then stops populating the current field and takes the next

            foreach(string line in source)
            {
                if(currentField == SPECIAL_LIMIT)
                {
                    accumulator.Add(line);
                    continue;
                }

                FieldInfo field = fields[currentField];

                field.SetValue(movie, line);

                currentField++;
            }

            fields[SPECIAL_LIMIT].SetValue(movie, accumulator);

            return movie;
        }


        [ContextMenu("Test (Creation of content)")]
        private void Test()
        {
            int indexTest = 0;

            Movie m = CreateMovieFromText(indexTest);

            SetDescription(m);
        }


        [ContextMenu("Test (Access of the UXML)")]
        private void AccessALabel()
        {
            Label label = document.rootVisualElement.Q<Label>(name: "Title", className: "line");

            Debug.Log($"The Title content is {label.text}");
        }
    }
}



using UnityEngine;
using System.Reflection;
using UnityEngine.UIElements;

namespace Abduction.UI
{

    public class Descriptor : MonoBehaviour
    {
        [SerializeField]
        private UIDocument document;


        /// <summary>
        /// Sets the description of a movie in the UI
        /// </summary>
        private void SetDescription(Movie movie)
        {
            PropertyInfo[] properties = typeof(Movie).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Label field = document.rootVisualElement.Q<Label>($"#{property.Name}", ".line");

                field.text = (string)property.GetValue(movie);
            }
        }
    }
}

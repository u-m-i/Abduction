using UnityEngine;

namespace Abduction
{
    public class Poster : MonoBehaviour
    {

        [SerializeField]
        private GameObject UI; 

        /// 
        private void OnMouseDown()
        {
            UI.SetActive(true);
        }
    }
}

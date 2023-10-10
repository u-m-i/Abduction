using UnityEngine;
using UnityEngine.UI;

namespace Abduction
{

    [AddComponentMenu("Abduction/PosterDectector")]
    public class PosterDetector: MonoBehaviour
    {
        [SerializeField]
        private int length;

        [Space(4)]

        [SerializeField]
        private LayerMask postersLayer;

        [Space(4)]

        [SerializeField]
        private Camera cam;

        [Space(4)]

        private Image aim;



        private void Update()
        {
            Vector3 position = Input.mousePosition;

            position.z = 40f;

            position = cam.ScreenToWorldPoint(position);


#if UNITY_EDITOR 
            Debug.DrawRay(transform.position, position - transform.position, Color.blue);
#endif

            Ray ray = cam.ScreenPointToRay(position);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, length, postersLayer))
            {
                Debug.Log("A poster can be activated");
                // Activate the aim
            }
            else
            {
                // Erase the input listener
            }
        }
    }
}

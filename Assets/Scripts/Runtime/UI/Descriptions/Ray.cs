using UnityEngine;
using Abduction.UI;


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

        [Header("User")]

        [Space(4)]

        [SerializeField]
        private CanvasGroup aim;

        [Space(4)]

        [SerializeField]
        private Descriptor descriptor;



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
                aim.alpha = 1.0f;
                if(Input.GetMouseButtonDown(0))
                {
                    descriptor.ShowCase((int) hit.rigidbody.drag);
                }
            }
            else
            {
                aim.alpha = 0.3f;
                // Erase the input listener
            }
        }
    }
}

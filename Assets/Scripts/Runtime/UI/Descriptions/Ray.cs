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
        private Aim aim;

        [Space(4)]

        [SerializeField]
        private Descriptor descriptor;



        private void Update()
        {
            Vector3 position = Input.mousePosition;

            position.z = 100f;

            position = cam.ScreenToWorldPoint(position);

            Debug.DrawRay(transform.position, position - transform.position, Color.blue);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, length, postersLayer))
            {
                // Activate the aim
                aim.Activate();
                if(Input.GetMouseButtonDown(0))
                {
                    descriptor.ShowCase(this, hit.transform.GetComponent<Poster>().index);

                    // Make sure still not listening
                    enabled = false;
                }
            }
            else
            {
                aim.Deactivate();
            }
        }
    }
}

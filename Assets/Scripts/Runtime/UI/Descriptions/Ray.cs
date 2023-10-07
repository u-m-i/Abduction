using UnityEngine;

namespace Abduction
{

    public class Ray : MonoBehaviour
    {
        [SerializeField]
        private int length;

        [Space(4)]

        [SerializeField]
        private Camera cam;

        private void Update()
        {
            Vector3 position = Input.mousePosition;

            position.z = 40f;

            position = cam.ScreenToViewportPoint(position);

            Debug.DrawRay(transform.position, position - transform.position, Color.blue);
        }
    }
}

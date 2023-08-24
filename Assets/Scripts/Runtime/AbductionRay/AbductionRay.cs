using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

namespace Abduction
{
    public class AbductionRay : MonoBehaviour
    {
        #region Inspector

        [Header("Character Settings")]

        [SerializeField,Space(4)]
        private FirstPersonMovement inputReceptor;

        [SerializeField,Space(4)]
        private int minusOne = -256;

        #endregion

        private Transform draggee;

        private Rigidbody holderBody;

        private Vector3 criticPoint;

        private Vector3 pad;

        private Vector3 buffer;

        private Renderer renderer;



        private void Awake()
        {

            renderer = GetComponent<Renderer>();

            // Making the final point of the abduction ray.

            criticPoint = new Vector3
            {
                x = renderer.bounds.center.x,
                y = (transform.position.y + 5f),
                z = renderer.bounds.center.z
            };

        }


        private void OnTriggerEnter(Collider other)
        {

            if(draggee)
                return;

            inputReceptor.enabled = false;

            GetComponent<Collider>().enabled = false;

            holderBody = other.gameObject.GetComponent<Rigidbody>();

            holderBody.useGravity = false;

            draggee = other.transform;

            buffer = draggee.position;

            StartCoroutine(Abduct());
        }
    

        private IEnumerator Abduct()
        {

            pad = new Vector3(0.035f, 0.15f, 0.035f);

            // Create the compensatory value for the x and z value
            
            AxisDirection();

            while (draggee.position.y <= criticPoint.y)
            {

                CalculateCritialLimit();

                draggee.position = buffer;

                yield return new WaitForFixedUpdate();
            }

            holderBody.useGravity = true;

            draggee = null;

            inputReceptor.enabled = true;

            yield break;

        }


        private void AxisDirection()
        {
            if(draggee.position.x > criticPoint.x)
            {
                pad.x *= -1;
            }

            if(draggee.position.z > criticPoint.z)
            {
                pad.z *= -1;
            }
        }


        /// <summary>
        /// Calculate y  given the x and advance x in time
        /// </summary>
        private void CalculateCritialLimit()
        {

            if(!(draggee.position.x >= criticPoint.x && pad.x > 0) || !(draggee.position.x <= criticPoint.x && pad.x < 0))
               buffer.x += pad.x;

            if (!(draggee.position.z >= criticPoint.z && pad.z > 0) || !(draggee.position.z <= criticPoint.z && pad.z < 0))
                buffer.z += pad.z;

            buffer.y += pad.y;
        }
    }
}
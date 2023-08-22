using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

namespace Abduction
{
    public class AbductionRay : MonoBehaviour
    {

        [Header("Character Settings")]

        [SerializeField,Space(4)]
        private FirstPersonMovement inputReceptor;

        [SerializeField,Space(4)]
        private int minusOne = -256;

        private Transform draggee;

        private Rigidbody holderBody;


        private Vector3 criticPoint;

        private Vector3 holderVec;

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

            GetComponent<Collider>().enabled = false;

            holderBody = other.gameObject.GetComponent<Rigidbody>();

            holderBody.useGravity = false;

            draggee = other.transform;

            inputReceptor.enabled = false;

            StartCoroutine(Abduct());
        } 

        private IEnumerator Abduct()
        {

            // |v1.x| - v2.x , |v1.y| - v2.y, |v1.z| - v2.z


            holderVec = new Vector3(0.035f, 0.15f, 0.035f);

            // Create the compensatory value for the x and z value
            AxisDirection();

            while (draggee.position.y <= criticPoint.y)
            {

                CalculateCritialLimit();

                draggee.position += holderVec;

                yield return new WaitForFixedUpdate();
            }

            holderBody.useGravity = true;

            draggee = null;

            inputReceptor.enabled = true;

            yield break;

        }


        /// Factor to reduce
        private void AxisDirection()
        {

            Debug.Assert(draggee.position.x > criticPoint.x , "The draggee <i>x</i> position is not being considered major than the Beam ray");
            if(draggee.position.x > criticPoint.x)
            {
                holderVec.x *= -1;
            }

            // Factor to increase

            if(draggee.position.z > criticPoint.z)
            {
                holderVec.z *= -1;
            }

            Debug.Log(holderVec);
        }


        /// Calculate y  given the x and advance x in time
        // The final output is a Vector3
        private void CalculateCritialLimit()
        {

            if(draggee.position.x >= criticPoint.x)
                holderVec.x = 0;

            if(draggee.position.z >= criticPoint.z)
                holderVec.z = 0;

        }
    }
}
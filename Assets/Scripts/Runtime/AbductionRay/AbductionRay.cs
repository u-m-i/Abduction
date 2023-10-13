using UnityEngine;
using System.Collections;

namespace Abduction
{
    public class AbductionRay : MonoBehaviour
    {
        #region Inspector

        [Header("Character Settings")]

        [SerializeField,Space(4)]
        private FirstPersonMovement inputReceptor;


        [SerializeField, Space(4)]
        private Transform debuger;

        #endregion

        private Transform draggee;

        private Rigidbody holderBody;

        private Vector3 criticPoint;

        private Vector3 pad;

        private Vector3 buffer;

        private Renderer meshRenderer;



        private void Awake()
        {

            meshRenderer = GetComponent<Renderer>();

            // Making the final point of the abduction ray.

            criticPoint = new Vector3
            {
                x = meshRenderer.bounds.center.x,
                y = (transform.position.y + 5f),
                z = meshRenderer.bounds.center.z
            };

            debuger.position = criticPoint;
        }


        private void OnTriggerEnter(Collider other)
        {
            if(draggee)
                return;

            inputReceptor.enabled = false;

            holderBody = other.gameObject.GetComponent<Rigidbody>();

            holderBody.useGravity = false;

            holderBody.velocity = Vector3.zero;

            holderBody.angularVelocity = Vector3.zero;

            holderBody.constraints =
                RigidbodyConstraints.FreezeAll & RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationZ;

            GetComponent<Collider>().enabled = false;

            draggee = other.transform;

            buffer = other.transform.position;

            StartCoroutine(Abduct());
        }
    

        private IEnumerator Abduct()
        {

            pad = new Vector3(0.035f, 0.06f, 0.035f);

            // Create the compensatory value for the x and z value
            
            AxisDirection();

            
            while (buffer.y <= criticPoint.y)
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

            if((buffer.x >= criticPoint.x && pad.x > 0) || (buffer.x <= criticPoint.x && pad.x < 0))
            {
            }
            else
            {
                buffer.x += pad.x;
            }

            if ((buffer.z >= criticPoint.z && pad.z > 0) || (buffer.z <= criticPoint.z && pad.z < 0))
            {
            }
            else
            {
                buffer.z += pad.z;
            }

            buffer.y += pad.y;
        }
    }
}

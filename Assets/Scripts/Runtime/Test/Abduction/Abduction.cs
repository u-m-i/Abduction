using UnityEngine;
using System.Collections;

namespace Nuruk.Test
{
    public class Abduction : MonoBehaviour
    {

        [SerializeField]
        private Transform[] targets;

        [SerializeField,Space(4)]
        private GameObject inputReceptor;

        [SerializeField,Space(4)]
        private Transform draggee;

        private float realLimit;

        private float criticX;

        private float holderX;

        private Vector3 holderVec;

        private float epsilon = 0.00035f;

        private void Awake()
        {
            Renderer r = GetComponent<Renderer>();

            realLimit = transform.position.y;

            criticX = r.bounds.center.x;
        }


        private void OnTriggerEnter(Collider other)
        {

            if(draggee)
                return;

            other.gameObject.GetComponent<Rigidbody>().useGravity = false;

            draggee = other.transform;

            StartCoroutine(Abduct());

        } 

        private IEnumerator Abduct()
        {

            holderX = 0;

            // Error in while condition
            while(holderX >= criticX )
            {

                CalculateCritialLimit();

                draggee.position += holderVec;

                yield return new WaitForFixedUpdate();
            }

        }


        /// Calculate y  given the x and advance x in time
        // The final output is a Vector3
        private void CalculateCritialLimit()
        {

            // Increments X by epsilon
            holderX += epsilon;

            //

            holderVec.y = 0f;
            holderVec.z = 0f;

        }
    }
}
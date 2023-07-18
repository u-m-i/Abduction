
using System;
using UnityEngine;
using System.Collections;

namespace Nuruk.Test
{
    public class Abduction : MonoBehaviour
    {

        [SerializeField,Space(4)]
        private GameObject inputReceptor;

        private Transform draggee;

        private Rigidbody holderBody;


        private Vector3 criticPoint;

        private Vector3 holderVec;


        private void Awake()
        {
            Renderer r = GetComponent<Renderer>();

            // Making the final point of the abduction ray.
            criticPoint = new Vector3(r.bounds.center.x, transform.position.y, r.bounds.center.z);

        }


        private void OnTriggerEnter(Collider other)
        {

            if(draggee)
                return;

            GetComponent<Collider>().enabled = false;

            holderBody = other.gameObject.GetComponent<Rigidbody>();

            holderBody.useGravity = false;

            draggee = other.transform;

            draggee.LookAt(transform,new Vector3(0,1,0));

            StartCoroutine(Abduct());

        } 

        private IEnumerator Abduct()
        {

            holderVec = new Vector3(0.035f, 0.15f, -0.035f);

            // Create the compensatory value for the x value
            AxisDirection();

            while(draggee.position.y <= criticPoint .y)
            {

                Debug.Log("Running");

                CalculateCritialLimit();

                draggee.position += holderVec;

                yield return new WaitForFixedUpdate();
            }

            holderBody.useGravity = true;

            draggee = null;

            yield break;

        }


        /// Factor to reduce
        private void AxisDirection()
        {

            if(draggee.position.x > criticPoint.x)
            {
                holderVec.x *= -1;
                return;
            }

            // Factor to increase
            holderVec.x *= 1;

        }


        /// Calculate y  given the x and advance x in time
        // The final output is a Vector3
        private void CalculateCritialLimit()
        {

            if((int) draggee.position.x == (int)criticPoint.x)
                holderVec.x = 0;

            if((int) draggee.position.z == (int)criticPoint.z)
                holderVec.z = 0;

        }
    }
}
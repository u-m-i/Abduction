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

        private Transform draggee;

        private Rigidbody holderBody;


        private float criticY;

        private float criticX;

        private float holderX;

        private float holderY;

        private Vector3 criticPoint;

        private Vector3 holderVec;


        private float epsilon = 0.000035f;

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

            holderBody = other.gameObject.GetComponent<Rigidbody>();

            holderBody.useGravity = false;

            draggee = other.transform;

            draggee.LookAt(transform,new Vector3(0,1,0));

            StartCoroutine(Abduct());

        } 

        private IEnumerator Abduct()
        {

            holderVec = new Vector3(0.035f, 0.15f, 0.035f);

            // Create the compensatory value for the x value
            AxisDirection();

            while(draggee.position.y <= criticPoint .y)
            {


                CalculateCritialLimit();

                draggee.position += holderVec;

                yield return new WaitForFixedUpdate();
            }



            yield break;

        }

        private void AxisDirection()
        {

            // Factor to reduce
            if(draggee.position.x > criticPoint.x)
                holderVec.x *= -1;

            // Factor to increase
            holderVec.x *= 1;

        }


        /// Calculate y  given the x and advance x in time
        // The final output is a Vector3
        private void CalculateCritialLimit()
        {   
        }
    }
}
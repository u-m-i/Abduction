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

            criticPoint = new Vector3(r.bounds.center.x, transform.position.y, r.bounds.center.z);

        }


        private void OnTriggerEnter(Collider other)
        {

            if(draggee)
                return;


            other.gameObject.GetComponent<Rigidbody>().useGravity = false;

            draggee = other.transform;

            draggee.LookAt(transform,new Vector3(0,1,0));

            StartCoroutine(Abduct());

        } 

        private IEnumerator Abduct()
        {

            holderX = holderY= 0;

            while(holderX >= criticX )
            {

                CalculateCritialLimit();

                draggee.position += holderVec;

                yield return new WaitForFixedUpdate();
            }

            yield break;

        }


        /// Calculate y  given the x and advance x in time
        // The final output is a Vector3
        private void CalculateCritialLimit()
        {

        }
    }
}
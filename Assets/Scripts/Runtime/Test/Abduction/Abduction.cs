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

        private float maximum = 10f;


        private void Awake()
        {
            Renderer r = GetComponent<Renderer>();

            maximum = transform.position.y;

            Debug.Log(r.bounds.max);

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

            float subtrahend = 0;


            while(maximum >= 0 )
            {
                yield return new WaitForSeconds(1.4f);

                subtrahend += 0.4f;
                maximum -= subtrahend;

                // Todo: Use the limit of the center.x to sum with an epsilon until is equal or major.  
                draggee.position = new Vector3(draggee.position.x, (draggee.position.y + subtrahend),draggee.position.z);

                // yield return new WaitForFixedUpdate();
            }

        }
    }
}
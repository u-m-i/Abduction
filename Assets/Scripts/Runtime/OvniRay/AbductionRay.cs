using UnityEngine;
using System.Collections;

namespace Abduction
{
    
    public class AbductionRay : MonoBehaviour
    {

        private Transform alienT;

        private Vector3 heightBuffer;


        private void OnTriggerEnter(Collider other)
        {
            alienT = other.transform;

            alienT.gameObject.GetComponent<Rigidbody>().useGravity = false;

            StartCoroutine(Abduct());
        }

        private IEnumerator Abduct()
        {
            // 10m   maxium height

            float maxium = 10f;

            float subtrahend = 0;


            while(maxium >= 0 )
            {
                yield return new WaitForSeconds(1.4f);

                subtrahend += 0.4f;
                maxium -= subtrahend;

                alienT.position = new Vector3(alienT.position.x, (alienT.position.y + subtrahend),alienT.position.z);

                yield return new WaitForFixedUpdate();
            }

        }
    }
}
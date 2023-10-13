using UnityEngine;
using System.Collections;

namespace Abduction
{
    public class SolidityChecker : MonoBehaviour
    {
        private Collider m_collider;

        private void Awake()
        {
            m_collider = GetComponent<Collider>();
        }

        private void OnTriggerExit(Collider other)
        {
            StartCoroutine(Wait());
        }


        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.75f);

            m_collider.isTrigger = false;
        }
    } 
}
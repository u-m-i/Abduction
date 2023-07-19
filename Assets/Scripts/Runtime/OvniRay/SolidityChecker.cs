using UnityEngine;

namespace Abduction
{
    public class SolidityChecker : MonoBehaviour
    {

        private Collider c;

        private void Awake()
        {
            c = GetComponent<Collider>();
        }

        private void OnTriggerExit(Collider other)
        {
            c.isTrigger = false;

            
        }
    }
}
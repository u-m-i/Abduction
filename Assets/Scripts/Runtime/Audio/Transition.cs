using UnityEngine;

namespace Abduction.Audio
{ 
    public class Transition : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private const string TRIGGER_NAME = "Change";


        private void Awake()
        {
            Debug.Assert(animator != null, "Remember assing an animator");
        }

        private void OnTriggerEnter(Collider other)
        {
            animator.SetTrigger(TRIGGER_NAME);
        }

    }
}


using UnityEngine;


namespace Abduction.StateBehaviour
{
    public abstract class State : MonoBehaviour
    {
        public abstract void OnRun();

        public abstract void OnSwap();
    }
}
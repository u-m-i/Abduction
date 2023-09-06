using UnityEngine;


namespace Abduction.StateBehaviour
{
    public abstract class State : ScriptableObject 
    {

        public abstract void OnRun();

        public abstract void OnSwap();

    }
}
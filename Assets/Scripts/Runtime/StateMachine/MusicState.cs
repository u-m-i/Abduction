using UnityEngine;
using Abduction.Audio;

namespace Abduction.StateBehaviour
{

    /// <summary>
    /// Dictates the state for the music
    /// </summary>
    public class Forest : State
    {
        [SerializeField]
        private Fader fader;


        public override void OnRun()
        {
            // Check alterations
        }


        public override void OnSwap() 
        {
            Transition();
        }


        private void Transition()
        {
            // Use the fader to transition between stages
        }
    }
}

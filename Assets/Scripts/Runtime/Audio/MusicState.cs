using System;
using UnityEngine;
using Abduction.StateBehaviour;

namespace Abduction.Audio
{

    /// <summary>
    /// Dictates the state for the music
    /// </summary>
    [Serializable]
    public class Musical : State
    {

        public AudioClip Clip;

        public AnimationCurve In;

        public AnimationCurve Out;



        public override void OnRun()
        {
        }


        public override void OnSwap() 
        {

        }


        private void Transition()
        {
        }
    }
}

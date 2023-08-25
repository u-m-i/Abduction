using UnityEngine;
using System.Collections;



using System;

namespace Abduction.Audio
{

    ///<summary>
    /// Plays the music with transitions
    ///</summary>
    public class Fader : MonoBehaviour
    {

        [Serializable]
        public struct Stage
        {
            public AudioClip clip;

            public AnimationCurve transitionIn;

            public AnimationCurve transisionOut;
        }

        [SerializeField]
        private Stage[] stages;



        private AnimationCurve @in;

        private AnimationCurve @out;

        

        public void FadeBetween()
        {
            @in = stages[0].transitionIn;
            @out = stages[1].transisionOut;
        }


        public void AnalizeLerp()
        {

        }

    }
}
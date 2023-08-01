using UnityEngine;

/// BACKLOG
/// Update each stage with a different animation curve.
/// Change stage.
/// Detect the entry of a new stage.

namespace Abduction.Test.Audio
{

    [System.Serializable]
    public struct Stage
    {
        public AudioClip clip;

        public AnimationCurve transition;
    }


    public class AudioManager : MonoBehaviour
    {

        [SerializeField]
        private Stage[] stages;


        public static AudioManager Instance;


        [HideInInspector]
        public Stage currentStage;

        private void Awake()
        {
            Instance = this;
            currentStage = stages[0];
        }


        public Stage[] ServeStages()
        {
            return stages;
        }
    }
}
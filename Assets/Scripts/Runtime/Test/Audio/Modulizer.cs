using UnityEngine;
using System.Collections;


/// The character enters a determined middle space and then the audio changes.
    // The audio changes with a little fade.
    // But the player can not go back.  


namespace Abduction.Test.Audio
{

    ///<summary>
    /// Plays the music with transitions
    ///</summary>
    public class Modulizer : MonoBehaviour
    {
        #region Inspector

        [SerializeField,Space(3)]
        private AudioSource audioSource;

        #endregion

        #region REMOVE

        private void Start()
        {
            PlayMusic();
        }

        #endregion


        ///<summary>
        /// Play the current stage ambient music. 
        ///</summary>
        private void PlayMusic()
        {

            audioSource.clip = AudioManager.Instance.currentStage.clip;

            audioSource.Play();

        }


        private IEnumerator FadeIn()
        {
            while(audioSource.volume <= 0)
            {

                audioSource.volume -= 0.034f;

                yield return new WaitForFixedUpdate();

            }

            // Play the next ambient music
            PlayMusic();

        }


        private IEnumerator FadeOut()
        {
            while(audioSource.volume >= 0.84f)
            {

                audioSource.volume += 0.034f;

                yield return new WaitForFixedUpdate();

            }

        }
    }
}
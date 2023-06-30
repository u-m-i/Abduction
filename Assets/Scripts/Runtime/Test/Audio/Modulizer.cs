using UnityEngine;
using System.Collections;


/// The character enters a determined middle space and then the audio changes.
    // The audio changes with a little fade.
    // But the player can not go back.  


namespace Abduction.Test
{

    ///<summary>
    /// Percieved the player position and fades between files. 
    ///</summary>
    public class Modulizer : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        [Tooltip("Sort the audio clips in ascendancy order.")]
        private AudioClip[] stages;

        [SerializeField,Space(3)]
        private AudioSource audioSource;

        #endregion

        private IEnumerator clipHanger;


        ///<summary>
        /// Creates the Linked List for the audio stages.
        ///</summary>
        private void FormatArrayToLinked()  =>
            clipHanger = stages.GetEnumerator();


        private void Awake()
        {
            FormatArrayToLinked();

            PlayLoop();
        }


        ///<summary>
        /// 
        ///</summary>
        private void PlayLoop()
        {

            clipHanger.MoveNext();

            // Play in a loop the current node.
            audioSource.clip = (AudioClip) clipHanger.Current;

            audioSource.Play();

        }


        private void OnTriggerEnter(Collider other)
        {
            PlayLoop();

        }
    }
}
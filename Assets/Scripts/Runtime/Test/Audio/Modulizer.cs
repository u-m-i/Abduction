using UnityEngine;
using System.Collections.Generic;


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

        [SerializeField]
        [Tooltip("Sort the audio clips in ascendancy order.")]
        private AudioClip[] stages;


        private IEnumerator<AudioClip> clipHanger;

        ///<summary>
        /// Creates the Linked List for the audio stages.
        ///</summary>
        private void FormatArrayToLinked()  =>
            clipHanger = stages.GetEnumerator() as IEnumerator<AudioClip>;


        ///<summary>
        /// C
        ///</summary>
        private void Start()
        {
            FormatArrayToLinked();

            PlayLoop();
        }


        ///<summary>
        /// 
        ///</summary>
        private void PlayLoop()
        {
            // Play in a loop the current node.

        }


        ///<summary>
        ///  
        ///</summary>
        private void OnTriggerEnter(Collider other)
        {
            // Activate the animation
            
        }
    }
}
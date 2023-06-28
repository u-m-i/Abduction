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


        private LinkedList<AudioClip> clipHanger;

        ///<summary>
        /// Creates the Linked List for the audio stages.
        ///</summary>
        private void FormatArrayToLinked() =>
            clipHanger = new LinkedList<AudioClip>(stages);

        private void Start()
        {
            FormatArrayToLinked();

            // Starts with the first
            PlayLoop();
        }

        private void PlayLoop()
        {
            // Play in a loop the current node.

                
        }

    }
}
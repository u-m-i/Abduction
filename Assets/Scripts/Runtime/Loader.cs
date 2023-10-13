using UnityEngine;
using UnityEngine.SceneManagement;

namespace Abduction.SceneControl
{

    /// <summary>
    /// Introduces the scene for the begining, this object must be in a scene called Entry
    /// </summary>
    public class Loader : MonoBehaviour
    {
        [SerializeField]
        private int sceneIndex;

        [Space(4)]

        [SerializeField]
        private LoadSceneMode loadMode;

        private void Awake()
        {
            SceneManager.LoadSceneAsync(sceneIndex,loadMode);
        }
    }
}

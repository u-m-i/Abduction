using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [Space(3)]

    [SerializeField]
    private AnimationCurve transitionCurve;


    private const float EPSILON = 0.2121f;

    private float incrementalTime = 0f;


    private void Awake() =>
        audioSource.volume = 0.0f;


    private void Update()
    {
        if(audioSource.volume <= 1.0f)
        {
            audioSource.volume = transitionCurve.Evaluate(incrementalTime);
            incrementalTime += EPSILON * Time.deltaTime;
        }
    }
}


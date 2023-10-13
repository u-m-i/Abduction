using UnityEngine;

public class PlayInterface : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The audio source GO called abduction with the abduction clip")]
    private AudioSource m_abduction;

    [SerializeField]
    [Tooltip("The audio source called ship with the ship clip")]
    private AudioSource m_ship;


    public void PlayAbduction()
    {
        m_abduction.Play();

    }


    public void PlayShip()
    {
        m_ship.Play();
    }
}

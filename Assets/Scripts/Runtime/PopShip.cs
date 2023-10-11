using UnityEngine;

public class PopShip : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;

    [Space(4)]

    [SerializeField]
    private Animator ray;


    private void Awake()
    {
        sphere.SetActive(true);

        ray.gameObject.SetActive(false);
        ray.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        sphere.SetActive(false);

        ray.gameObject.SetActive(true);
        ray.enabled = true;

        other.GetComponent<Rigidbody>().drag = 18;
        GetComponent<Collider>().isTrigger = false;
    }
}

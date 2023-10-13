using UnityEngine;
using System.Collections;

public class PopShip : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;

    [Space(4)]

    [SerializeField]
    private Animator ray;

    private Rigidbody body;


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

        body = other.GetComponent<Rigidbody>();

        StartCoroutine(SlowEffect());
    }


    private IEnumerator SlowEffect()
    {
        body.drag = 30;

        yield return new WaitForSeconds(3);

        GetComponent<Collider>().isTrigger = false;

        body.drag = 8;
    }
}

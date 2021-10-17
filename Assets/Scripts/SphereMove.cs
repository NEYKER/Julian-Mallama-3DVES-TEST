using UnityEngine;

public class SphereMove : MonoBehaviour
{
    GameObject sphere = null;

    private void Awake()
    {
        sphere = gameObject;
        sphere.GetComponent<Rigidbody>().velocity = transform.forward * 20;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

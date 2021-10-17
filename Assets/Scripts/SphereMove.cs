using UnityEngine;

public class SphereMove : MonoBehaviour
{
    GameObject sphere = null;

    private void Awake()
    {
        sphere = gameObject;
        sphere.GetComponent<Rigidbody>().velocity = transform.forward * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ShootSphereController : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab = null;
    public void Attack()
    {
        Instantiate(spherePrefab,gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
    }
}

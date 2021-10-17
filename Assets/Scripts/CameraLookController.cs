using UnityEngine;

public class CameraLookController : MonoBehaviour
{
    Camera cam = null;
    Transform target = null;

    float zoom = 1; //zoom que es asignado junto con la rueda del raton para acercarse o alejarse del objeto

    float zoomAmount = 50;// multiplicador de velocidad 

    Vector3 previousPosition = new Vector3(0,0,0);

    void Start()//encuentra las referencias de los objetos
    {
        cam = FindObjectOfType<Camera>();
        target = GameObject.Find("Ditto").GetComponent<Transform>();
    }

    void Update()
    {
        RotateAroundObject();
    }

    public void RotateAroundObject() //Controla la rotacion y limites de acercamiento de la camara
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);

            cam.transform.Translate(new Vector3(0, 0, -zoom));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomAmount * Time.deltaTime;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomAmount * Time.deltaTime;
        }

        zoom = Mathf.Clamp(zoom, 0.8f, 10f);
    }
}

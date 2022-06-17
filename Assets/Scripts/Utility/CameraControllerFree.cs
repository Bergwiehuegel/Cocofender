using UnityEngine;

public class CameraControllerFree : MonoBehaviour
{

    [Header("Camera Settings")]
    public float panSpeed = 30f;
    public float dragSpeed = 1f;

    private bool allowMovement = true;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            allowMovement = !allowMovement;
        }

        if (!allowMovement)
        {
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(- Input.GetAxis("Mouse Y") * dragSpeed, - -Input.GetAxis("Mouse X") * dragSpeed, 0));
            float X = transform.rotation.eulerAngles.x;
            float Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
}

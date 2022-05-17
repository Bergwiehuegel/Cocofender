using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float minMaxDistance = 60;
    public Transform gameCenter;
    //public float panBorderThickness = 10f;

    [Header("Zooming")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minTilt = 25f;
    public float maxTilt = 70f;


    private bool allowMovement = true;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            allowMovement = !allowMovement;

        if (!allowMovement)
            return;

        //Get  Y-Pos for Movement  
        float myY = transform.position.y;

        //Input.mousePosition.y >= Screen.height - panBorderThickness)
        if (Input.GetKey("w"))
        {
            Vector3 targetDir = gameCenter.position - transform.position;
            transform.Translate(targetDir.normalized * panSpeed * Time.deltaTime, Space.World);
            transform.position = new Vector3(transform.position.x, myY, transform.position.z);
        }
        if (Input.GetKey("s"))
        {
            Vector3 distPoint = new Vector3(gameCenter.position.x, transform.position.y, gameCenter.position.z);
            if (Vector3.Distance(distPoint, transform.position) >= minMaxDistance)
                return;

            Vector3 targetDir = gameCenter.position - transform.position;
            transform.Translate(-targetDir.normalized * panSpeed * Time.deltaTime, Space.World);
            transform.position = new Vector3(transform.position.x, myY, transform.position.z);
        }


        transform.LookAt(gameCenter);
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        { 
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
        

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //Aktuelle Position und Rotation
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Vector3 rotEular = rot.eulerAngles;

        //Adjust position to scroll Level
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        //Adjust X-Rotation to scroll Level
        rotEular.x = Mathf.Clamp(pos.y, minTilt, maxTilt);
        rot.eulerAngles = rotEular;
        transform.rotation = rot;
    }
}

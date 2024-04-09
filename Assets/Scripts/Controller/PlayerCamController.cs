using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    public float sensitiveX;
    public float sensitiveY;
    public Transform Orientation;
    public float xRotation;
    public float yRotation; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitiveX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitiveY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate cam and rotation
        transform.rotation  = Quaternion.Euler(xRotation,yRotation,0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

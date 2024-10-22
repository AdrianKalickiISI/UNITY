using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float sensitivity = 200f;  
    public Transform playerBody;      

    float xRotation = 0f;  

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        
        playerBody.Rotate(Vector3.up * mouseX);

        
        xRotation -= mouseY;
        
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

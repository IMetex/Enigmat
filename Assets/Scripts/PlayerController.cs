using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f;

    private float rotationX = 0;
    private float rotationY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        //// Object Movement
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        //transform.Translate(movement);

        // Camera Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX * sensitivity, 0);
    }
}


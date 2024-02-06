using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float moveSpeed = 10f; // Speed of camera movement
    public float rotationSpeed = 10f; // Speed of camera rotation

    private bool isScrollButtonPressed = false;

    void Update()
    {
        // Check if the scroll mouse button is pressed down
        if (Input.GetMouseButtonDown(2))
        {
            isScrollButtonPressed = true;
        }
        // Check if the scroll mouse button is released
        else if (Input.GetMouseButtonUp(2))
        {
            isScrollButtonPressed = false;
        }

        // Move the camera if the scroll mouse button is not pressed
        if (!isScrollButtonPressed)
        {
            // Get mouse position in screen coordinates
            Vector3 mousePosition = Input.mousePosition;

            // Check if mouse is at the edge of the screen and move camera accordingly
            Vector3 moveDirection = Vector3.zero;
            if (mousePosition.x <= 0)
            {
                moveDirection -= Vector3.right;
            }
            else if (mousePosition.x >= Screen.width - 1)
            {
                moveDirection += Vector3.right;
            }
            if (mousePosition.y <= 0)
            {
                moveDirection -= Vector3.forward;
            }
            else if (mousePosition.y >= Screen.height - 1)
            {
                moveDirection += Vector3.forward;
            }

            // Move the camera based on edge scrolling
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // Get keyboard input for manual camera movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Move the camera based on keyboard input
            Vector3 keyboardMovement = new Vector3(horizontalInput, 0f, verticalInput);
            transform.position += keyboardMovement * moveSpeed * Time.deltaTime;
        }
        // Rotate the camera around the player if the scroll mouse button is pressed
        else
        {
            // Get mouse input to rotate the camera around the player
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

            // Rotate the camera around the player based on mouse input
            transform.RotateAround(playerTransform.position, Vector3.up, mouseX);
        }
    }
}

using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    public float moveSpeed = 10f; // Speed of the player's movement
    private Vector3 targetPosition; // Destination position for the cube

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Set the target position to the point where the ray hits
                targetPosition = hit.point;
            }
        }

        // Move the cube towards the target position
        MovePlayer();
    }

    void MovePlayer()
    {
        // Calculate the direction for the player to move towards the target position
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f; // Ensure the player doesn't move up or down
        direction.Normalize();

        // Move the player in the calculated direction
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if the player is close enough to the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Snap the player to the target position when it's close enough
            transform.position = targetPosition;
        }
    }
}

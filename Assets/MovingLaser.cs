using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How far the laser moves in each direction")]
    public float moveDistance = 5f;

    [Tooltip("How fast the laser moves")]
    public float speed = 2f;

    [Tooltip("Choose which direction the laser moves")]
    public MovementAxis axis = MovementAxis.Horizontal;

    private Vector3 startPosition;

    public enum MovementAxis
    {
        Horizontal, // Moves left/right (X axis)
        Vertical,   // Moves up/down (Y axis)
        Forward     // Moves forward/back (Z axis)
    }

    void Start()
    {
        // Remember where the laser started
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate how far along the movement we are (0 to 1 and back)
        float movement = Mathf.PingPong(Time.time * speed, moveDistance);

        // Apply movement based on chosen axis
        Vector3 offset = Vector3.zero;

        switch (axis)
        {
            case MovementAxis.Horizontal:
                offset = new Vector3(movement, 0, 0);
                break;
            case MovementAxis.Vertical:
                offset = new Vector3(0, movement, 0);
                break;
            case MovementAxis.Forward:
                offset = new Vector3(0, 0, movement);
                break;
        }

        // Move the laser to its new position
        transform.position = startPosition + offset;
    }
}
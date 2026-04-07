using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    public float jumpForce = 7f;
    public float gravity = -20f;

    public Camera cam1;
    public Camera cam2;

    private int currentLane = 1;
    private float verticalVelocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.forward * forwardSpeed;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (currentLane > 0) currentLane--;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            if (currentLane < 2) currentLane++;

        float targetX = (currentLane - 1) * laneDistance;
        float currentX = transform.position.x;
        float deltaX = targetX - currentX;

        float snapThreshold = 0.05f;

        // Calculate movement for this frame
        float moveX = deltaX * laneChangeSpeed * Time.deltaTime;

        // Check overshoot: if next position crosses target
        bool willOvershoot = Mathf.Abs(moveX) > Mathf.Abs(deltaX);

        if (Mathf.Abs(deltaX) < snapThreshold || willOvershoot)
        {
            // Snap to lane
            Vector3 pos = transform.position;
            pos.x = targetX;
            transform.position = pos;
            move.x = 0;
        }
        else
        {
            // Smooth movement
            move.x = deltaX * laneChangeSpeed;
        }

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0) verticalVelocity = -1f;
            if (Input.GetKeyDown(KeyCode.Space)) verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity;
        controller.Move(move * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (cam1 != null && cam2 != null) {
                switchCamera();
            }
        }
    }

    void switchCamera()
    {
       
        if (cam1.targetDisplay == 1)
        {
            cam2.targetDisplay = 1;
            cam1.targetDisplay = 0;
        }
        else
        {
            cam2.targetDisplay = 0;
            cam1.targetDisplay = 1;
        }
    }
}   

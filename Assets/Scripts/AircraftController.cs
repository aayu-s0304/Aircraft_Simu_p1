using UnityEngine;

public class AircraftController : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 20f;
    public float turnSpeed = 50f;
    public float pitchSpeed = 25f;
    public float rollSpeed = 3f;
    public float maxRollAngle = 45f;

    private float currentRoll = 0f;
    private float minY;

    void Start()
    {
        // Lock starting ground height
        minY = transform.position.y;
    }

    void Update()
    {
        HandleForwardMovement();
        HandlePitch();
        HandleTurning();
        PreventFalling();
    }

    void HandleForwardMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        }
    }

    void HandlePitch()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Smooth ascend (rotate slightly upward)
            transform.Rotate(-pitchSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    void HandleTurning()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Gradual roll towards -45
            currentRoll = Mathf.Lerp(currentRoll, -maxRollAngle, rollSpeed * Time.deltaTime);

            // Gradual turn (Yaw)
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Gradual roll towards +45
            currentRoll = Mathf.Lerp(currentRoll, maxRollAngle, rollSpeed * Time.deltaTime);

            // Gradual turn
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        }
        else
        {
            // Return to level
            currentRoll = Mathf.Lerp(currentRoll, 0f, rollSpeed * Time.deltaTime);
        }

        // Apply roll only on Z axis
        Vector3 currentRotation = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRoll);
    }

    void PreventFalling()
    {
        if (transform.position.y < minY)
        {
            Vector3 pos = transform.position;
            pos.y = minY;
            transform.position = pos;
        }
    }
}
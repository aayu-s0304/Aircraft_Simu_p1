using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    private Vector3 lastTargetPosition;

    void Start()
    {
        if (target != null)
            lastTargetPosition = target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // How much plane moved since last frame
        Vector3 deltaMovement = target.position - lastTargetPosition;

        // Move camera by same amount
        transform.position += deltaMovement;

        // Always look at plane
        transform.LookAt(target.position);

        // Store position for next frame
        lastTargetPosition = target.position;
    }
}
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera noseCamera;

    void Start()
    {
        noseCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
            noseCamera.enabled = !noseCamera.enabled;
        }
    }
}
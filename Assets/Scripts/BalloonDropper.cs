using UnityEngine;

public class BalloonDropper : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Transform dropPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(balloonPrefab, dropPoint.position, Quaternion.identity);
        }
    }
}
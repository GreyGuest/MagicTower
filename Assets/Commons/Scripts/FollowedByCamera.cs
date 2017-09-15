using UnityEngine;

public class FollowedByCamera : MonoBehaviour
{
    public Camera targetCamera;

    private Vector3 offset;

    private void Start()
    {
        offset = targetCamera.transform.position - transform.position;
    }

    private void Update()
    {
        targetCamera.transform.position = transform.position + offset;
    }
}
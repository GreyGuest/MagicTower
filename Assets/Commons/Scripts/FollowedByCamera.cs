using UnityEngine;

public class FollowedByCamera : MonoBehaviour
{
    public Camera camera;

    private Vector3 offset;

    private void Start()
    {
        offset = camera.transform.position - transform.position;
    }

    private void Update()
    {
        camera.transform.position = transform.position + offset;
    }
}
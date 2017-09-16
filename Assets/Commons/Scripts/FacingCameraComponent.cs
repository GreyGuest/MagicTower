using UnityEngine;

public class FacingCameraComponent : MonoBehaviour
{
    private GameObject targetCamera;

    private void Start()
    {
        targetCamera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        transform.rotation = targetCamera.transform.rotation;
    }
}
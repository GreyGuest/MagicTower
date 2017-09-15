using UnityEngine;

public class FacingCameraComponent : MonoBehaviour
{
    private GameObject camera;

    private void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        transform.rotation = camera.transform.rotation;
    }
}
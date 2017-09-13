using UnityEngine;

public class FacingCameraComponent : MonoBehaviour
{

	public Camera camera;
	
	private void Update ()
	{
		transform.rotation = camera.transform.rotation;
	}
}

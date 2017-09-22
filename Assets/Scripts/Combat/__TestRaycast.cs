using UnityEngine;

public class __TestRaycast : MonoBehaviour {

    Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("We hit" + hit.collider.name + " " + hit.point);
            }
        }
	}
}

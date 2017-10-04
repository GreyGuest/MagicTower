using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmill_PaddleRotation : MonoBehaviour {
    public Vector3 Rotation;
    public float speed;
    // Use this for initialization
    Quaternion startRotation;
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		transform.Rotate(Rotation * Time.deltaTime * speed);
	}
}

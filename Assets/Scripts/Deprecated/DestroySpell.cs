using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpell : MonoBehaviour {

	//Уничтожаем обьект 
	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemy" || col.tag == "Textures") {
			Destroy (gameObject);
		}
	}
}

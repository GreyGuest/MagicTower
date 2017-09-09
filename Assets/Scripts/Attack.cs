using UnityEngine;

public class Attack : MonoBehaviour
{
	private float impulsePower = 80.0f;
	public GameObject spellPrefab;

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			SpawnSpell ();
		}
	}

	void SpawnSpell()
	{
		GameObject newSpell = Instantiate (spellPrefab, transform.position, transform.rotation) as GameObject;
		newSpell.GetComponent<Rigidbody>().AddForce (transform.forward * impulsePower, ForceMode.Impulse);
	}
}

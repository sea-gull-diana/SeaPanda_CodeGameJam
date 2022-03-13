using UnityEngine;

public class Algue : MonoBehaviour {

    public static int nbAlgues = 0;
	// Use this for initialization
	
	void OnTriggerEnter2D(Collider2D other) {

		// trigger coin pickup function if a helicopter collides with this
		nbAlgues++;
		Destroy(gameObject);
	}
}

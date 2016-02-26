using UnityEngine;
using System.Collections;

public class DESTROYEVERYTHING : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "plus" || collision.gameObject.tag == "minus") {
			Destroy (collision.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class MoveTruck : MonoBehaviour {

	public float speed = 30;

	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * speed;
	}
}

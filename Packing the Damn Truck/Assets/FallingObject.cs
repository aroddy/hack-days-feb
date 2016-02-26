using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	public float delay;
	public GameObject o;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn",delay,delay);
	}

	//Create a new box
	void Spawn () {
		for (int i = 0; i < (Random.value * 3); i++) {
			Instantiate(o,new Vector2(Random.Range(-22,22),17),Quaternion.identity);
		}
	}
}

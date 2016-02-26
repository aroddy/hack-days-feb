using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		audio.Play(44100);
	}
}

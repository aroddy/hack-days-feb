using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Collide : MonoBehaviour {

	public Text end;
	private float time;
	public Text timeText;
	private int score;
	public Text scoreText;
	public AudioClip pooSound;
	public AudioClip boxSound;
	public AudioClip winSound;
	public AudioClip loseSound;
	public AudioSource a;
	public float timeToWin;
	public int scoreToWin;

	void Start(){
		a = GetComponent<AudioSource>();
		score = 0;
		scoreText.text = "Score:" + score.ToString ();
		time = timeToWin;
		timeText.text = "Time:" + time.ToString ();
		end.text = "";
	}

	void Update() {
		time -= Time.deltaTime;
		timeText.text = "Time:" + time.ToString ();
		if (time <= 0) {
			timeText.text = "Time:0";
			EndGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "plus" || collision.gameObject.tag == "minus") {
			Destroy(collision.gameObject);
		}
		if (gameObject.tag == "Player") {
			if (collision.gameObject.tag == "minus") {
				a.PlayOneShot(pooSound,2f);
				score = 0;
			} else if (collision.gameObject.tag == "plus") {
				a.PlayOneShot(boxSound,1f);
				score = score + 1;
			}
		}
		scoreText.text = "Score:" + score.ToString ();
	}

	void EndGame(){
		
		if (score >= scoreToWin) {
			end.text = "You Win!";
			a.PlayOneShot (winSound, 3f);
		} else {
			end.text = "You Lose!";
			a.PlayOneShot (loseSound, 3f);
		}

		Time.timeScale = 0;
		Application.Quit();
	}
}

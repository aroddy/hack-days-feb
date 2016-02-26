using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Paavo
{
	public class Player : MovingObject
	{
		public float restartLevelDelay = 1f;
		public int pointsPerFood = 1;
		public int pointsPerSoda = 3;
		public int wallDamage = 1;
		public Text foodText;

		private int food;

		protected override void Start ()
		{
			food = 0;

			foodText.text = "Freight: " + food;

			base.Start ();
		}

		private void OnDisable ()
		{
			GameManager.instance.playerFoodPoints = food;
		}

		private void Update ()
		{
			if (!GameManager.instance.playersTurn) 
			{
				return;
			}
			
			int horizontal = 0;
			int vertical = 0;
			
			horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
			
			vertical = (int) (Input.GetAxisRaw ("Vertical"));
			
			if (horizontal != 0)
			{
				vertical = 0;
			}

			if (horizontal != 0 || vertical != 0)
			{
				AttemptMove<Wall> (horizontal, vertical);
			}
		}
		
		protected override void AttemptMove <T> (int xDir, int yDir)
		{
			//food--;
			
			//foodText.text = "Food: " + food;
			
			base.AttemptMove <T> (xDir, yDir);
			
			RaycastHit2D hit;
			
			if (Move (xDir, yDir, out hit)) 
			{
				
			}
			
			CheckIfGameOver ();
			
			GameManager.instance.playersTurn = false;
		}
		
		protected override void OnCantMove <T> (T component)
		{
			Wall hitWall = component as Wall;
			
			//hitWall.DamageWall (wallDamage);
		}
		
		private void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "Exit")
			{
				foodText.text = "Freight delivered!";

				Invoke ("Restart", restartLevelDelay);
				
				enabled = false;
			}
			else if (other.tag == "Food")
			{
				food += pointsPerFood;
				
				foodText.text = "+" + pointsPerFood + " Freight: " + food;
				
				other.gameObject.SetActive (false);
			}
			else if (other.tag == "Soda")
			{
				food += pointsPerSoda;
				
				foodText.text = "+" + pointsPerSoda + " Freight: " + food;
				
				other.gameObject.SetActive (false);
			}
		}

		private void Restart ()
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		
		public void LoseFood (int loss)
		{
			food -= loss;
			
			foodText.text = "-"+ loss + " Freight: " + food;
			
			CheckIfGameOver ();
		}
		
		private void CheckIfGameOver ()
		{
			
		}
	}
}


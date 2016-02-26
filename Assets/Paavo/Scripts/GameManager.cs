using UnityEngine;
using System.Collections;

namespace Paavo 
{
	using System.Collections.Generic;
	using UnityEngine.UI;
	
	public class GameManager : MonoBehaviour 
	{
		public float levelStartDelay = 2f;						
		public float turnDelay = 0.1f;							
		public int playerFoodPoints = 0;						
		public static GameManager instance = null;				
		[HideInInspector] public bool playersTurn = true;				
		
		private Text levelText;									
		private GameObject levelImage;							
		private BoardManager boardScript;						
		private int level = 1;			
		private bool playerCantMove; 
		private bool doingSetup = true;	
				
		void Awake() 
		{
			if (instance == null) 
			{
				instance = this;
			}

			else if (instance != this) 
			{
				Destroy (gameObject);	
			}

			DontDestroyOnLoad(gameObject);

			boardScript = GetComponent<BoardManager>();

			InitGame();
		}

		void OnLevelWasLoaded(int index) 
		{
			level++;

			if (level == 6) 
			{
				EndGame ();
			} 
			else 
			{
				InitGame ();
			}
		}

		void InitGame()	
		{
			doingSetup = true;

			levelImage = GameObject.Find("LevelImage");

			levelText = GameObject.Find("LevelText").GetComponent<Text>();

			levelText.text = "Day " + level;

			levelImage.SetActive(true);

			Invoke("HideLevelImage", levelStartDelay);

			boardScript.SetupScene(level);
		}

		void EndGame()
		{
			doingSetup = true;

			levelImage = GameObject.Find("LevelImage");

			levelText = GameObject.Find("LevelText").GetComponent<Text>();

			levelText.text = "Week Over!" +
							 "\n" + playerFoodPoints + " total freight delivered!" +
							 "\nYou earned $" + (playerFoodPoints * 5) + "!";

			levelImage.SetActive(true);
		}

		void HideLevelImage() 
		{
			levelImage.SetActive(false);

			doingSetup = false;
		}

		void Update() 
		{
			if (playersTurn || playerCantMove || doingSetup) 
			{				
				return;
			}

			StartCoroutine (MoveEnemies ());
		}

		IEnumerator MoveEnemies() 
		{
			playerCantMove = true; 

			yield return new WaitForSeconds(turnDelay);

			if (true) 
			{
				yield return new WaitForSeconds (turnDelay);
			}

			playersTurn = true;

			playerCantMove = false; 
		}
	}
}


using UnityEngine;
using System.Collections;

namespace Paavo
{
	public class SoundManager : MonoBehaviour 
	{
		public AudioSource musicSource;                 
		public static SoundManager instance = null;                  
		public float lowPitchRange = .95f;             
		public float highPitchRange = 1.05f;            

		void Awake ()
		{
			if (instance == null) 
			{
				instance = this;
			} 
			else if (instance != this) 
			{
				Destroy (gameObject);
			}

			DontDestroyOnLoad (gameObject);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour {

	public AudioSource menuMusic;
	public AudioSource inGameMusic;
	public AudioSource deadMusic;
	public AudioSource efxSource;
	public static SoundManager instance = null;
	public bool playMusic = true;
	public Scene currentScene;

	public float lowPitchRange = 0.95f;
	public float highPitchRange = 1.05f;

	void Awake () {

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle (AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}

	void PlayBGM () 
	{
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "Main") 
		{
			
			inGameMusic.Play ();
		}
		if (currentScene.name == "Menu") 
		{
			
			menuMusic.Play ();
		}
	}
}

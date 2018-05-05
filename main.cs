using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public SaveFile saveFile;
	public static GameManager instance = null; // is the gamobject gamanager needed?
	public bool gameEnd = false;
	public bool gamePause;
	public GameObject hall;
	public GameObject safe;
	public Text scoreText;
	public Text gameoverText;

	private HallManager bm; // just random supplies, loot and enemies, no random tiles
	private safeManager sm;


	public void Awake ()
	{
		saveFile = GetComponent<SaveFile> ();
		Cursor.visible = true;
	}

	public void Update ()
	{
		// if some button is clicked - gamePause == true
		if (gamePause == true) {
			Time.timeScale = 0;
			// another click gamePause == false
		} else {
			Time.timeScale = 1;
		}
		if (gameEnd == true){
			Gameover();
		}
	}

	public void FieldChange ()
	{
		// if player met stairs, hall and safe switch positions.

	}

	public void Gameover ()
	{
		SaveFile.saveScore ();
		gameoverText = "You get caught!"
		if (player.score > saveFile.highScore) {
			scoreText = "Congratulations! New High Score!"
		}
		//gameEnd == true;
		BackToMenu ();
	}


	public void BackToMenu ()
	{
		if (Input.anyKey){
			SceneManager.LoadScene ("Menu");
		}
	}
}

// actually no need to divide gameman boardman soundman...

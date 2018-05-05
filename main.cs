using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public SaveFile saveFile;
	public static GameManager instance = null;
	public bool gameEnd = false;
	public GameObject hall;
	public GameObject safe;

	private HallManager bm;


	public void Awake ()
	{
		saveFile = GetComponent<SaveFile> ();
		Cursor.visible = true;
	}

	public void Update ()
	{
		//pausing game
	}

	public void FieldChange ()
	{
		// if player met exit, hall and safe switch positions.
	}

	public void Gameover ()
	{
		SaveFile.saveScore ();
		gameEnd == true;
		StartCoroutine (BackToMenu ());
	}

	IEnumerator BackToMenu ()
	{
		yield return new WaitForSecondsRealtime (5);
		SceneManager.LoadScene ("Menu");
	}
}

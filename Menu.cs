using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Text highScoreText;
	public Text gameStartText;

	public void StartButton ()
	{
		gameStartText.color = Color.black;
		SceneManager.LoadScene ("Main");
	}


	public void rankButton ()
	{

	}

	//public void shareButton () java-android studio add-on

}

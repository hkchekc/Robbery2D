using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	public GameObject gameManager;


	void Awake () 
	{
		if (gameManager == null) {
			Instantiate (gameManager);
		}

	}
	

}
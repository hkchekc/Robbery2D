﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour {

	public int score;
	public int gold;
	public bool checkLocalHighScore;
	public int highScore = 0;

	private string fileName;
	private string filePath;

	public void saveScore ()
	{
		fileName = "score.txt";
		filePath = Path.Combine (Application.persistentDataPath, fileName);


		if (!File.Exists (fileName))
		{
			File.Create (filePath);
		}
		if (File.Exists (fileName))
		{
			//gold = gold + Player;
			// 
			if (score > highScore) {
				highScore = score;
			}
		}

	}

	public void loadScore ()
	{
		//DontDestroyOnLoad;
	}
}

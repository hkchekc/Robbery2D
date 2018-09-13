using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HallManager : MonoBehaviour {


	public int hallColumns =5;
	public int hallRows = 10;
	public GameObject door;
	public GameObject[] floorTiles;
	public GameObject[] blockTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;
	public GameObject stone;
	public GameObject safeDoor;
	public GameObject key;
	public int floorCount;
	public int blockTilesCount;
	public int level;

	private Rigidbody2D rb2d;
	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void Awake ()
	{
		SetupScene (level);
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.velocity = new Vector2 (CameraController.cameraSpeed, 0);
	}
		
	void Update ()
	{
		if (GameManager.instance.gameEnd == true) 
		{
			rb2d.velocity = Vector2.zero;
		}
	}

	void InitialList()
	{
		gridPositions.Clear();

		for (int x = 1; x < hallColumns - 1; x++) 
		{
			for (int y = 1; y < hallRows - 1; y++) 
			{
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}


	}
	void Boardsetup () 
	{
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < hallColumns + 1; x++)
		{
			for (int y = -1; y < hallRows + 1; y++)
			{
					GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
					if (x == -1 || x == hallColumns || y == -1 || y == hallRows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0.0f), Quaternion.identity) as GameObject;

					instance.transform.SetParent (boardHolder);
					
			}
		}

	}

	Vector3 RandomPositions ()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPositions = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPositions;
	}

	void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
	{
		int ObjectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < ObjectCount; i++)
		{
			Vector3 randomPositions = RandomPositions();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate(tileChoice, randomPositions, Quaternion.identity);
		}
	}

	public void SetupScene (int level)
	{
		Boardsetup ();
		InitialList ();
		int enemyCount = (int)Mathf.Log (level, 2f);
		LayoutObjectAtRandom (floorTiles, floorCount - 2, floorCount + 2);
		Instantiate (safeDoor, new Vector3 (Random.Range(2, hallColumns), hallRows-1, 0.0f), Quaternion.identity);
		Instantiate (stone, new Vector3 (Random.Range(2, hallColumns-2), Random.Range(2, hallRows-2), 0.0f), Quaternion.identity);
		Instantiate (key, new Vector3 (Random.Range (2,4), Random.Range(2,4), 0.0f), Quaternion.identity);

	}
		
}

	
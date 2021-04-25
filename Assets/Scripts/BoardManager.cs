using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count
	{
		public int maximum;
		public int minimum;

		public Count ( int min, int max){
			maximum=max;
			minimum=min;
		}
	}

	//general values
	public int columns = 8;
	public int rows = 8;

	public Count wallCount = new Count (5, 9);
	//public Count foodCount = new Count (1, 5); 
	public GameObject exit;
	//public GameObject[] wallTiles;
	//public GameObject[] foodTiles;
	public GameObject[] floorTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3> ();

	void InitializeList()
	{
		gridPositions.Clear();

		for(int x = 1; x < columns-1; x++)
		{
			for(int y = 1; y < rows-1; y++)
			{
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}
	void BoardSetup()
	{
		boardHolder = new GameObject("Board").transform;
		for(int x = -1; x < columns+1; x++)
		{
			for (int y = -1; y < rows + 1; y++) 
			{
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				if(x == -1 || y == -1 || x == columns || y == rows)
					toInstantiate = outerWallTiles[Random.Range(0,outerWallTiles.Length)];
				GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
	{
		
		int objectCount = Random.Range (minimum, maximum + 1);
	
		for(int i = 0; i<objectCount; i++)
		{
			Vector3 randomPosition = RandomPosition();
			randomPosition = BringForward (randomPosition);
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	public Vector3 BringForward(Vector3 vector)
	{
		vector.Set (vector.x, vector.y, vector.z -1);
		return vector;
	}

	public void SetupScene(int level)
	{
		BoardSetup ();
		InitializeList ();
		//sLayoutObjectAtRandom (wallTiles,wallCount.minimum,wallCount.maximum);
		/*
		LayoutObjectAtRandom (foodTiles,foodCount.minimum, foodCount.maximum);*/
		int enemyCount = (int)Mathf.Log (level, 2f);
		LayoutObjectAtRandom (enemyTiles, enemyCount,enemyCount);
		//Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
	}
	void Update(){
		
	}
}


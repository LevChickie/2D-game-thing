using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float levelStartDelay = 2f;
	public float turnDelay = 0.1f;
	public static GameManager instance = null;
	public BoardManager boardScript;
	public int playerFoodPoints = 100;
	[HideInInspector] public bool playersTurn = true;
	private int level=12;

	private Text levelText;
	private GameObject levelImage;
	private bool doingSetup;
	private bool enemiesMoving;
	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject); 
		DontDestroyOnLoad (gameObject); 
		boardScript = GetComponent<BoardManager> ();
		InitializeGame ();
	}

	private void OnLevelWasLoaded(int index){
		level++;
		InitializeGame ();
	}
	private void HideLevelImage()
	{
		levelImage.SetActive (false);
		doingSetup = false;
	}
	void InitializeGame()
	{
		boardScript.SetupScene (level); 
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MovingObjects {

	public UIScreenManager uiManager;
	public int wallDamage = 1;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public Text foodText;
	public float restartLevelDelay = 1f;

	public AudioClip moveSound1;
	public AudioClip moveSound2;
	public AudioClip eatSound1;
	public AudioClip eatSound2;
	public AudioClip drinkSound1;
	public AudioClip drinkSound2;
	public AudioClip gameOverSound;

	private Animator animator;
	private int food;

	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();
		//food = GameManager.instance.playerFoodPoints;
		//foodText.text = "Food: " + food;
		base.Start (); 
		uiManager = new UIScreenManager ();
	}

	private void OnDisable()
	{
	//	GameManager.instance.playerFoodPoints = food;	
	}

	private void CheckIfGameOver(){
		if (food <= 0) {
		//	SoundManager.instance.PlaySingle (gameOverSound);
		//	SoundManager.instance.musicSource.Stop ();
		//	GameManager.instance.GameOver ();
		}
	}

	protected override void AttemptMove <T>( int xDir, int yDir)
	{
		//food--;
		//foodText.text = "Food: " + food;
		base.AttemptMove<T> (xDir, yDir);
		RaycastHit2D hit;
		if (Move (xDir, yDir, out hit)) {
		//	SoundManager.instance.RandomizeSfx (moveSound1, moveSound2);
		}
		CheckIfGameOver ();
		animator.SetTrigger ("playerMove");

		//GameManager.instance.playersTurn = false;
	}
	// Update is called once per frame
	void Update () {
		int horizontal = 0;
		int vertical = 0;
		if(Input.GetKey(KeyCode.E)){
			PlayerAttack();
		}
		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");
		if (horizontal != 0) {
			vertical = 0;
		}
		if (horizontal != 0 || vertical != 0) {
			AttemptMove<Wall> (horizontal, vertical);  
		}
	}
	void PlayerAttack(){
		animator.SetTrigger ("playerAttack");
		uiManager.ChangeName ("Arra");
	
	}
	protected override void OnCantMove <T> (T component)
	{
		Wall hitWall = component as Wall;
		hitWall.DamageWall (wallDamage);
		animator.SetTrigger ("playerAttack");
	}

	private void Restart ()
	{
		//SceneManager.LoadScene(0);
		Application.LoadLevel (Application.loadedLevel);
	}
	public void LoseFood(int loss)
	{
		animator.SetTrigger ("playerHit");
		//food -= loss;
		//foodText.text = "-" + loss + " Food: " + food;
		CheckIfGameOver ();
	}
	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Exit") {
			Invoke ("Restart", restartLevelDelay);
			enabled = false;
		} else if (other.tag == "Food") {
		//	food += pointsPerFood;
		//	SoundManager.instance.RandomizeSfx (eatSound1, eatSound2);
		//	foodText.text = "+" + pointsPerFood + " Food: " + food;
		//	other.gameObject.SetActive (false);
		} else if (other.tag == "Soda") {
		//	food += pointsPerSoda;
		//	SoundManager.instance.RandomizeSfx (drinkSound1, drinkSound2);
		//	foodText.text = "+" + pointsPerFood + " Food: " + food;
		//	other.gameObject.SetActive (false);
		}

	}
}

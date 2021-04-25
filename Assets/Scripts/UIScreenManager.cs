using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenManager : MonoBehaviour {

	private Image imageOfNpc;
	private Text nameOfNpc;
	// Use this for initialization
	void Start () {
		imageOfNpc = GetComponent<Image>();
		nameOfNpc = GetComponent<Text>();
		nameOfNpc.text = "arra";
	}
	public void ChangeName (string name){
		//nameOfNpc.text = name;
	}
	public void ChangeImage(Image art){
		//imageOfNpc = art;
	}

	// Update is called once per frame
	void Update () {
		//nameOfNpc.text = "elem";
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnclick : MonoBehaviour {

	public GameObject WebCom;
	public GameObject Batten;

	public void Onclick()
	{   WebCom.SetActive (true);
		Batten.SetActive (true);
		//Debug.Log ("クリックしたやで");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

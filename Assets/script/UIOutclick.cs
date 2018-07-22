using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOutclick : MonoBehaviour {
	
	public GameObject WebCom;
	public GameObject Batten;

	public void Onclick()
	{   WebCom.SetActive (false);
		Batten.SetActive (false);
		GameObject[] tagobjs = GameObject.FindGameObjectsWithTag("CameraYoukai");
		foreach (GameObject obj in tagobjs) {
			Destroy (obj);
		}

		//Debug.Log ("クリックしたやで");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

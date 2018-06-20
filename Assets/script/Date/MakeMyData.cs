using UnityEngine;
using System.Collections;

public class MakeMyData : MonoBehaviour {

	private MyData data;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			data = ScriptableObject.CreateInstance <MyData> ();
			data.myName = "Name";
			data.hp = Random.Range (10, 50);
			data.attackPower = 10f;
			Debug.Log (data.myName + " : " + data.hp + " : " + data.attackPower);
		} else if(Input.GetButtonDown("Fire2")) {
			Debug.Log (data.myName + " : " + data.hp + " : " + data.attackPower);
		}
	}
}

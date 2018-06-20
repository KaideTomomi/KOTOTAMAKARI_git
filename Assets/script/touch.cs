using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {
	Vector3 downPoint ;
	Vector3 dir ;
	public float kaitenSpeed;
	public GameObject player;
	// public GameObject tama;

	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
	}

	void OnMouseDown (){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			
			//Debug.Log(hit.point);
			downPoint = hit.point;
		}

	}

	void OnMouseDrag(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.name == "Plane") {
				// Debug.Log (hit.point);
				dir = hit.point - downPoint;
				dir.Normalize ();
				//Debug.Log (dir);
				// tama.transform.position = hit.point;
				Quaternion q = Quaternion.LookRotation(dir);          // 向きたい方角をQuaternion型に直す
				player.transform.rotation = Quaternion.RotateTowards(transform.rotation, q, kaitenSpeed * Time.deltaTime);   // 向きを q に向けてじわ～っと変化させる.

			}
		}
	}
	void OnMouseUp(){
		//ßDebug.Log("Mouse up up!");
	}
}

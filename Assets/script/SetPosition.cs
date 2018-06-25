using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPosition : MonoBehaviour {
	public GameObject playerObject ;
	public float offset ;
	public float offsetZ ;

	// Use this for initialization
	void Start () {
		if ( PositionManager.hasPos( SceneManager.GetActiveScene().name ) ){
			Vector3 pos = PositionManager.getPos( SceneManager.GetActiveScene().name );
			playerObject.transform.position = new Vector3( pos.x+ offset, pos.y, pos.z+ offsetZ);
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
﻿using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.SceneManagement;  public class MouseMove : MonoBehaviour { 	Vector3 downPoint; 	Vector3 dir; 	public LayerMask LayerMask; 	public float AngleToGo; 	public float speed; 	public float distMin; 	public float rotSpeed = 1.0f;  	private Animator animCon;     bool onSlope = false;  	// Use this for initialization 	void Start () { 		animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する 	}  	// Update is called once per frame 	void Update () { 		if (Input.GetMouseButton(0)) 		{ 			// print("左ボタンが押されている"); 			animCon.SetBool("Run", true);  			RaycastHit hit; 			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 			if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask)) 			{ 				//Debug.Log (hit.point);  				// if ( isGrounded ){  				Vector3 targetPositon = hit.point; 				// 高さがずれていると体ごと上下を向いてしまうので便宜的に高さを統一 				if (transform.position.y != hit.point.y) 				{ 					targetPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z); 				} 				Quaternion targetRotation = Quaternion.LookRotation(targetPositon - transform.position); 				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);  				Vector3 targetDir = targetPositon - transform.position; 				float angle = Vector3.Angle(targetDir, transform.forward); 				//Debug.Log(angle);  				if ( angle < AngleToGo) 				{
                    Vector3 movedir = transform.forward;                     if (onSlope){
                        movedir.y = 0.8f;                     }                     gameObject.GetComponent<Rigidbody>().velocity = movedir * speed;                     //gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed; 					//Debug.Log( gameObject.GetComponent<Rigidbody>().velocity ); 				}  				if ( Vector3.Distance( targetPositon, gameObject.transform.position) < distMin) 				{ 					gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 				}  				// }  			} 		}else  		{ 			animCon.SetBool("Run", false); 		} 		if (Input.GetMouseButtonDown(0)) 		{ 		} 		if (Input.GetMouseButtonUp(0)) 		{ 			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 		} 	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ExitTrigger")
        {
            if (collision.gameObject.name == "movenext")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("hirayamap", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "moveback")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("testanimation", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "movesuzakumon")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("suzakumon", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "movebackhiraya")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("hirayamap", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "moveidonaka")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("idonaka", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "movebackhirayaido")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("hirayamap", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "movetogethukyou")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("togetukyou", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            if (collision.gameObject.name == "movetogethuback")
            {
                PositionManager.setPos(SceneManager.GetActiveScene().name, gameObject.transform.position);
                SceneNavigator.Instance.Change("hirayamap", 0.5f);
                //Debug.Log ("移動したいやで");
            }
            /*if (collision.gameObject.name == "movemathuotaizi"){ 				PositionManager.setPos (SceneManager.GetActiveScene ().name, gameObject.transform.position); 				SceneNavigator.Instance.Change("hirayamap", 0.5f);	 				//Debug.Log ("移動したいやで"); 			}*/

        }
        if (collision.gameObject.tag == "slope")         {
            // flagを立てる
            onSlope = true;             Debug.Log(onSlope);
        }     }

    void OnCollisionExit(Collision collision)     {         if (collision.gameObject.tag == "slope")         {
            // flagをoffにする 
            onSlope = false;             Debug.Log(onSlope);         }

    } }
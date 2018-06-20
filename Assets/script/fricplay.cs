using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fricplay : MonoBehaviour {

/*private Vector3 touchStartPos;
private Vector3 touchEndPos;*/

	public float speed = 3.0f;
	public float kaitenSpeed = 1200.0f;   // プレイヤーの回転速度（Public＝インスペクタで調整可能）
	private CharacterController charaCon;       // キャラクターコンポーネント用の変数
	private Animator animCon;  //  アニメーションするための変数


	// ■最初に1回だけ実行する処理
	void Start()
	{
		charaCon = GetComponent<CharacterController>(); // キャラクターコントローラーのコンポーネントを参照する
		animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			transform.position += this.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey ("down")) {
			transform.position -= this.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("right")) {
			transform.position += this.transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey ("left")) {
			transform.position -= this.transform.right * speed * Time.deltaTime;
		}




		if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
		{
			animCon.SetBool("Run", false);  //  Runモーションしない
		}

		else //  テンキーや3Dスティックの入力（GetAxis）がゼロではない時の動作
		{
			var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;  //  カメラが追従するための動作
			Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");  //  テンキーや3Dスティックの入力（GetAxis）があるとdirectionに値を返す
			animCon.SetBool("Run", true);  //  Runモーションする

			MukiWoKaeru(direction);  //  向きを変える動作の処理を実行する（後述）
			IdoSuru(direction);  //  移動する動作の処理を実行する（後述）
		}

	}

	// ■向きを変える動作の処理
	void MukiWoKaeru(Vector3 mukitaiHoukou)
	{
		Quaternion q = Quaternion.LookRotation(mukitaiHoukou);          // 向きたい方角をQuaternion型に直す
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, kaitenSpeed * Time.deltaTime);   // 向きを q に向けてじわ～っと変化させる.
	}


	// ■移動する動作の処理
	void IdoSuru(Vector3 idosuruKyori)
	{
		charaCon.Move(idosuruKyori * Time.deltaTime * speed);   // プレイヤーの移動距離は時間×移動スピードの値
	}

/*void Flick(){
	/*if (Input.GetKeyDown(KeyCode.Mouse0)){
		touchStartPos = new Vector3(Input.mousePosition.x,
			Input.mousePosition.y,
			Input.mousePosition.z);
	}

	if (Input.GetKeyUp(KeyCode.Mouse0)){
		touchEndPos = new Vector3(Input.mousePosition.x,
			Input.mousePosition.y,
			Input.mousePosition.z);
		GetDirection();
	}
}

void GetDirection(){
	float directionX = touchEndPos.x - touchStartPos.x;
	float directionY = touchEndPos.y - touchStartPos.y;
	string Direction;

	if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
		if (30 < directionX){
			//右向きにフリック
			Direction = "right";
		}else if (-30 > directionX){
			//左向きにフリック
			Direction = "left";
		}
	}
}else if (Mathf.Abs(directionX)<Mathf.Abs(directionY){
	if (30 < directionY){
		//上向きにフリック
		Direction = "up";
	}else if (-30 > directionY){
		//下向きのフリック
		Direction = "down";
	}
}else{
	//タッチを検出
	Direction = "touch";
}
	}

	switch (Direction){
		case "up":
		//上フリックされた時の処理
		break;

		case "down":
		//下フリックされた時の処理
		 break;

		case "right":
		//右フリックされた時の処理
		break;

		case "left":
		//左フリックされた時の処理
		break;

		case "touch":
	    //タッチされた時の処理
		break;
	}*/
		}
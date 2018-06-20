using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// bool hit = false ;
	
		public class FollowTarget : MonoBehaviour
		{
			public Transform target;
			public Vector3 offset = new Vector3(0f, 7.5f, 0f);


			private void LateUpdate()
			{
				// if (hit == false) {
					transform.position = target.position + offset;
				//}
			}
		}

		void OnCollisionEnter (Collision col)
		{
			//hit = true;
		}
		void OnCollisionExit (Collision col)
		{
			//hit = false;
		}
	}

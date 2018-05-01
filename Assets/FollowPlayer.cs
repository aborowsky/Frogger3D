using UnityEngine;

public class FollowPlayer : MonoBehaviour {
		public Transform player;
		public Vector3 cameraOffset;

		void Start(){
			cameraOffset.x = 0;
			cameraOffset.y = 5;
			cameraOffset.z = -5;
		}
		// Update is called once per frame
		void Update () {
			transform.position = player.position + cameraOffset;
		}
	}

using UnityEngine;

public class Player_Collision : MonoBehaviour {

	public Player_Movement movement;

	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.collider.tag == "obstacle"){
			movement.enabled = false;
		}
	}
}

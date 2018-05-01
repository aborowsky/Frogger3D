using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Transform player;
	public enum direction {North, South, East, West, None};
	public direction dir;

	void Update(){
		Vector3 newPos = player.position;
		if(dir == direction.East){
			newPos.x = player.position.x - 2.5f;
			transform.position = Vector3.Lerp (player.position, newPos, 1);
		}
		if(dir == direction.West){
			newPos.x = player.position.x + 2.5f;
			transform.position = Vector3.Lerp (player.position, newPos, 1);
		}
		if(dir == direction.South){
			newPos.z = player.position.z - 2.5f;
			transform.position = Vector3.Lerp (player.position, newPos, 1);
		}
		if(dir == direction.North){
			newPos.z = player.position.z + 2.5f;
			transform.position = Vector3.Lerp (player.position, newPos, 1);
			Debug.Log (newPos.z);
		}
		dir = direction.None;

	}
	// FixedUpdate is called once per frame (use fixed update whenever physics are involved)
	void FixedUpdate () {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			dir = direction.East;
		} 
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			dir = direction.West;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			dir = direction.South;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			dir = direction.North;
		}
	}
}


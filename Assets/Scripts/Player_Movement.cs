using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public Rigidbody rb;
	public float forwardForce = 4000f;
	public float sideForce = 120f;

	// Use this for initialization
	void Start () {

	}
	
	// FixedUpdate is called once per frame (use fixed update whenever physics are involved)
	void FixedUpdate () {
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if(Input.GetKey(KeyCode.LeftArrow)){
			rb.AddForce(-(sideForce * Time.deltaTime), 0, 0, ForceMode.VelocityChange);
		} 
		if(Input.GetKey(KeyCode.RightArrow)){
			rb.AddForce( sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}
}

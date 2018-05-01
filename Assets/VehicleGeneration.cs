using UnityEngine;

using System.Collections.Generic;

public class VehicleGeneration : MonoBehaviour {

	public GameObject[] vehicles;
	public List<GameObject> activeVehicles;
	public Transform startPos1;
	public Transform endPos1;
	// Use this for initialization
	void Start () {
		vehicles = GameObject.FindGameObjectsWithTag ("vehicle");
		InvokeRepeating ("generateRandom", 0.0f, 3.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb;
		foreach(GameObject vehicle in activeVehicles){
			checkBounds (vehicle);
			rb = vehicle.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (5, 0, 0);
		}
	}

	void generateRandom(){
		int rand = Random.Range(0, vehicles.Length);
		GameObject randomVehicle = Instantiate (vehicles [rand]);
		randomVehicle.transform.position = startPos1.position;
		randomVehicle.transform.Rotate (0, -90, 0);
		Rigidbody rb = randomVehicle.AddComponent<Rigidbody> ();
		rb.mass = 10;
		rb.angularDrag = 0;
		rb.AddForce (2000f * Time.deltaTime, 0, 0);
		activeVehicles.Add(randomVehicle);
	}

	void checkBounds(GameObject vehicle){
		if(vehicle.transform.position.x > endPos1.position.x){
			activeVehicles.Remove (vehicle);
			Destroy (vehicle);

		}
		
	}
}

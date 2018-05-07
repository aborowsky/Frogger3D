using UnityEngine;

using System.Collections.Generic;

public class VehicleGeneration : MonoBehaviour {

	public GameObject[] vehicles;
	public List<GameObject> activeVehicles;
	public GameObject[] startPositions;
	public GameObject[] endPositions;

	// Use this for initialization
	void Start () {
		startPositions = GameObject.FindGameObjectsWithTag ("startPos");
		endPositions = GameObject.FindGameObjectsWithTag ("endPos");

		vehicles = GameObject.FindGameObjectsWithTag ("vehicle");
		InvokeRepeating ("generateRandomVehicles", 0.0f, 3.0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb;
		VehicleData vd;
		foreach(GameObject vehicle in activeVehicles.ToArray()){
			checkVehicleBounds(vehicle);
			rb = vehicle.GetComponent<Rigidbody> ();

			vd = vehicle.GetComponent<VehicleData>();
			rb.velocity = new Vector3(vd.velocity, 0, 0);
		}
	}

	void generateRandomVehicles(){
		int rand;
		foreach(GameObject sp in startPositions){
			rand = Random.Range(0, vehicles.Length);
			GameObject randomVehicle = Instantiate(vehicles[rand]);
			randomVehicle.transform.position = sp.transform.position;

			// Fix rotation of vehicle on start
			VehicleData vd;
			if (randomVehicle.transform.position.x == -90) {
				randomVehicle.transform.Rotate (0, -90, 0);
				vd = randomVehicle.GetComponent<VehicleData>();
				vd.velocity = 5;


			} else if (randomVehicle.transform.position.x == 90){
				randomVehicle.transform.Rotate (0, 90, 0);
				vd = randomVehicle.GetComponent<VehicleData>();
				vd.velocity = -8;
			}

			Rigidbody rb = randomVehicle.AddComponent<Rigidbody> ();
			rb.mass = 20;
			rb.angularDrag = 0;
			activeVehicles.Add (randomVehicle);
			
		}

	}

	void checkVehicleBounds(GameObject vehicle){
		
		// Essentially hardcoded bounds , not sure how else to do it
		if(vehicle.transform.position.x > endPositions[0].transform.position.x){
			activeVehicles.Remove (vehicle);
			Destroy (vehicle);
		}

		if(vehicle.transform.position.x < endPositions[1].transform.position.x){
			activeVehicles.Remove (vehicle);
			Destroy (vehicle);
		}

		
	}
}

using UnityEngine;

using System.Collections.Generic;

public class TrainGeneration : MonoBehaviour {

	public GameObject[] trains;
	public List<GameObject> activetrains;
	public GameObject[] startPositions;
	public GameObject[] endPositions;

	// Use this for initialization
	void Start () {
		startPositions = GameObject.FindGameObjectsWithTag ("trainStartPos");
		endPositions = GameObject.FindGameObjectsWithTag ("trainEndPos");

		trains = GameObject.FindGameObjectsWithTag ("train");
		InvokeRepeating ("generateRandomtrains", 0.0f, 12.0f);
		//InvokeRepeating ("generateRandomtrains", 0.0f, 10.0f);

	}

	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb;
		TrainsData td;
		foreach(GameObject train in activetrains.ToArray()){
			checktrainBounds(train);
			rb = train.GetComponent<Rigidbody> ();

			td = train.GetComponent<TrainsData>();
			rb.velocity = new Vector3(td.velocity, 0, 0);
		}
	}

	void generateRandomtrains(){
		int rand;
		foreach(GameObject sp in startPositions){
			rand = Random.Range(0, trains.Length);
			GameObject randomtrain = Instantiate(trains[rand]);
			randomtrain.transform.position = sp.transform.position;

			// Fix rotation of train on start
			TrainsData td;
			if (randomtrain.transform.position.x == -90) {
				randomtrain.transform.Rotate (0, 0, 0);
				td = randomtrain.GetComponent<TrainsData>();
				td.velocity = 20;


			} else if (randomtrain.transform.position.x == 90){
				randomtrain.transform.Rotate (0, 180, 0);
				td = randomtrain.GetComponent<TrainsData>();
				td.velocity = -30;
			}

			Rigidbody rb = randomtrain.AddComponent<Rigidbody> ();
			rb.mass = 20;
			rb.angularDrag = 0;
			rb.useGravity = false;
			activetrains.Add (randomtrain);

		}

	}

	void checktrainBounds(GameObject train){

		// Essentially hardcoded bounds , not sure how else to do it
		if(train.transform.position.x > endPositions[0].transform.position.x){
			activetrains.Remove (train);
			Destroy (train);
		}

		if(train.transform.position.x < endPositions[1].transform.position.x){
			activetrains.Remove (train);
			Destroy (train);
		}


	}
}

using UnityEngine;

using System.Collections.Generic;

public class LogGeneration : MonoBehaviour {

	public GameObject[] logs;
	public List<GameObject> activelogs;
	public GameObject[] startPositions;
	public GameObject[] endPositions;

	// Use this for initialization
	void Start () {
		startPositions = GameObject.FindGameObjectsWithTag ("logStartPos");
		endPositions = GameObject.FindGameObjectsWithTag ("logEndPos");

		logs = GameObject.FindGameObjectsWithTag ("log");
		Debug.Log (logs);
		InvokeRepeating ("generateRandomlogs", 0.0f, 4.0f);

	}

	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb;
		LogsData ld;
		foreach(GameObject log in activelogs.ToArray()){
			checklogBounds(log);
			rb = log.GetComponent<Rigidbody> ();

			ld = log.GetComponent<LogsData>();
			rb.velocity = new Vector3(ld.velocity, 0, 0);
		}
	}

	void generateRandomlogs(){
		int rand;
		foreach(GameObject sp in startPositions){
			rand = Random.Range(0, logs.Length);
			GameObject randomlog = Instantiate(logs[rand]);
			randomlog.transform.position = sp.transform.position;

			// Fix rotation of log on start
			LogsData ld;
			if (randomlog.transform.position.x == -90) {
				randomlog.transform.Rotate (0, -90, 0);
				ld = randomlog.GetComponent<LogsData>();
				ld.velocity = 5;


			} else if (randomlog.transform.position.x == 90){
				randomlog.transform.Rotate (0, 90, 0);
				ld = randomlog.GetComponent<LogsData>();
				ld.velocity = -8;
			}

			Rigidbody rb = randomlog.AddComponent<Rigidbody> ();
			rb.mass = 20;
			rb.angularDrag = 0;
			rb.useGravity = false;
			activelogs.Add (randomlog);

		}

	}

	void checklogBounds(GameObject log){

		// Essentially hardcoded bounds , not sure how else to do it
		if(log.transform.position.x > endPositions[0].transform.position.x){
			activelogs.Remove (log);
			Destroy (log);
		}

		if(log.transform.position.x < endPositions[1].transform.position.x){
			activelogs.Remove (log);
			Destroy (log);
		}


	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//This should work 

public class GamePlay: MonoBehaviour
{

	public int score; 
	public int lives; 
	public int level; 
	public int time; 
	public Text score_text; 
	public Text lives_text; 
	public Text time_text; 
	public Text level_text; 
	public int  Minutes = 0;
	public int  Seconds = 0;

	public Transform player;

	private float   timeLeft;


	void Start()
	{
		timeLeft = 300.0f; 
		score = 0; 
		level =1; 
		lives = 3; 
		score_text.text = "0";
		lives_text.text = "3";

	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			//Know that there is actually contact happening 
			Debug.DrawRay(contact.point, contact.normal, Color.red);
		}
		if(collision.relativeVelocity.magnitude > 1)
		{
			lives = lives -1;  
		}

	}

	void Update()
	{
		score_text.text = player.position.x.ToString();
		time_text.text = time.ToString(); 
		timeLeft -= Time.deltaTime;
		time_text.text = "Time Left:" + Mathf.Round(timeLeft);
		if(level == 1)
		{
			timeLeft = 300.0f; 
		}
		if(timeLeft < 0)
		{
			//Start over the level somehow???
			Application.LoadLevel("gameOver");
		}       

		if(player.position.z > 300)//checks of the player is at the end of the road 
		{
			//Can the number based on the end of the map 
			level = level + 1; 
			if(level == 2)
			{
				timeLeft = 200.0f; 
			}
			if(level == 3)
			{
				timeLeft = 100.0f;
			}

			Vector3 newPos = player.position;
			newPos.z = 0f;
			player.position = Vector3.Lerp (player.position, newPos, 1);
		}

		if(time == 0)
		{
			lives = lives - 1; 
			lives_text.text = lives.ToString();             
			time = 100; 
			time_text.text = time.ToString(); 

			Vector3 newPos = player.position;
			newPos.z = 0f;
			player.position = Vector3.Lerp (player.position, newPos, 1);//move the player back to the beginning 

			level = 1; 
		}
		if(lives == 0)
		{
			//End game somehow??

			Application.LoadLevel("gameOver");
			//exit? 
			//Close? 
		}
	}

}
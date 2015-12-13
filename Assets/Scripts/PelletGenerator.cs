using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PelletGenerator : MonoBehaviour {

	private bool startTime = false;

	public void gameStart()
	{
		StartCoroutine(createPellet());
		startTime = true;
	}

	[SerializeField]
	private GameObject pelletTemplate = null;

	/// <summary>
	/// Time in seconds that a new pellet is created
	/// </summary>
	[SerializeField]
	private float initialPelletCreationInterval = 2f;

	/// <summary>
	/// Time of Round in Seconds
	/// </summary>
	[SerializeField]
	private int totalTimeOfRound = 30;

	[SerializeField]
	private int timeLeftInRound;

	void Update() {
		//End round shouldn't really be run from here.
		if (timeLeftInRound == 0) {
			startTime = false;
			Application.LoadLevel(Application.loadedLevel);
		}

		//Kind of hacky -- should fix
		if (startTime == true) {
			timeLeftInRound = totalTimeOfRound - (int)Time.timeSinceLevelLoad+3;
			GameObject.FindGameObjectWithTag("Time").GetComponent<Text>().text = ""+timeLeftInRound;
		}

	}

	private IEnumerator createPellet()
	{
		while (Time.time < totalTimeOfRound/2) {
			yield return new WaitForSeconds(initialPelletCreationInterval);
			generateRandomPellet();
		}
		while (Time.time > totalTimeOfRound/2 && Time.time <= totalTimeOfRound*3/4) {
			yield return new WaitForSeconds(initialPelletCreationInterval/2);
			generateRandomPellet();
		}
		while (Time.time > totalTimeOfRound*3/4 && Time.time <= totalTimeOfRound*5/6) {
			yield return new WaitForSeconds(initialPelletCreationInterval/4);
			generateRandomPellet();
		}
		while (Time.time > totalTimeOfRound*5/6 && Time.time <= totalTimeOfRound) {
			yield return new WaitForSeconds(initialPelletCreationInterval/8);
			generateRandomPellet();
		}
	}

	private void generateRandomPellet(){
		
		bool pointFound = false;
		
		while (!pointFound)
		{
			float xCoordinate = Random.Range(-CameraBounds.Instance.HorizontalEdge, CameraBounds.Instance.HorizontalEdge);
			float yCoordinate = Random.Range(-CameraBounds.Instance.VerticalEdge, CameraBounds.Instance.VerticalEdge);
			
			Vector3 pelletPosition = new Vector3(xCoordinate, yCoordinate, 0);
			
			if (Physics.OverlapSphere(pelletPosition, 1).Length == 0)
			{
				pointFound = true;
				GameObject.Instantiate(pelletTemplate, pelletPosition, Quaternion.identity); 
			}
		}
	}
}

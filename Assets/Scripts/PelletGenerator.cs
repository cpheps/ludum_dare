﻿using UnityEngine;
using System.Collections;

public class PelletGenerator : MonoBehaviour {
	public void gameStart(int totalTimeOfRound)
	{
		StartCoroutine(createPellet(totalTimeOfRound));
	}

	[SerializeField]
	private GameObject pelletTemplate = null;

	/// <summary>
	/// Time in seconds that a new pellet is created
	/// </summary>
	[SerializeField]
	private float initialPelletCreationInterval = 2f;

	private IEnumerator createPellet(int totalTimeOfRound)
	{
		float startTime = Time.time;

		while ((Time.time - startTime) < totalTimeOfRound/2) {
			yield return new WaitForSeconds(initialPelletCreationInterval);
			generateRandomPellet();
		}
		while ((Time.time - startTime) > totalTimeOfRound/2 && (Time.time - startTime) <= totalTimeOfRound*3/4) {
			yield return new WaitForSeconds(initialPelletCreationInterval/2);
			generateRandomPellet();
		}
		while ((Time.time - startTime) > totalTimeOfRound*3/4 && (Time.time - startTime) <= totalTimeOfRound*5/6) {
			yield return new WaitForSeconds(initialPelletCreationInterval/4);
			generateRandomPellet();
		}
		while ((Time.time - startTime) > totalTimeOfRound*5/6 && (Time.time - startTime) <= totalTimeOfRound) {
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

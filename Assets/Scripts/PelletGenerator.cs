using UnityEngine;
using System.Collections;

public class PelletGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject pelletTemplate = null;

	/// <summary>
	/// Time in seconds that a new pellet is created
	/// </summary>
	[SerializeField]
	private float pelletCreationInterval = 2f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void createPellet()
	{
		while (true) 
		{
			yield return new WaitForSeconds(pelletCreationInterval);

		}
	}
}

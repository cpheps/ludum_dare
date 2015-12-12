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
		StartCoroutine(createPellet());
	}
	
	private IEnumerator createPellet()
	{
		while (true) 
		{
			yield return new WaitForSeconds(pelletCreationInterval);

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
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoadScript : MonoBehaviour {
	[SerializeField]
	private Color32[] playerColors;

	[SerializeField]
	private GameObject pelletGenerator;

	[SerializeField]
	private GameObject snake;

	private List<GameObject> createdSnakes = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Debug.Log ("1");

		for (int count = 1; count <= 4; ++count)
		{
			Debug.Log (count + " a");
			int multiplier = count * (count % 2 == 0 ? 2 : -2 );
			Debug.Log (count + " b");
			GameObject newSnake = GameObject.Instantiate(snake, new Vector3(multiplier, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;
			Debug.Log (count + " c");

			Debug.Log (count + " d");
			SnakeController snakeController = newSnake.GetComponent<SnakeController>();
			Debug.Log (count + " e");
			snakeController.PlayerColor = playerColors[count - 1];
			Debug.Log (count + " f");
			createdSnakes.Add(newSnake);
			Debug.Log (count + " g");

		}
		Debug.Log ("2");


		StartCoroutine(startCountDown());
	}

	private IEnumerator startCountDown()
	{
		Debug.Log ("In");
		yield return new WaitForSeconds(3);
		Debug.Log ("Done Waiting");
		pelletGenerator.transform.SendMessage("gameStart");
		Debug.Log ("PelletGenerator Should have been called");

		foreach (GameObject snake in createdSnakes)
		{
			snake.transform.SendMessage("gameStart");
		}
	}
}

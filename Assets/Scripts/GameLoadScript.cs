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
		PlayerPrefs.SetString ("coilLeft", "A");
		PlayerPrefs.SetString ("coilRight", "S");

		for (int count = 1; count <= 4; ++count)
		{
			int multiplier = count * (count % 2 == 0 ? 2 : -2 );
			GameObject newSnake = GameObject.Instantiate(snake, new Vector3(multiplier, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;

			SnakeController snakeController = newSnake.GetComponent<SnakeController>();
			snakeController.PlayerColor = playerColors[count - 1];
			createdSnakes.Add(newSnake);
		}

		StartCoroutine(startCountDown());
	}

	private IEnumerator startCountDown()
	{
		yield return new WaitForSeconds(3);
		pelletGenerator.transform.SendMessage("gameStart");

		foreach (GameObject snake in createdSnakes)
		{
			snake.transform.SendMessage("gameStart");
		}
	}
}

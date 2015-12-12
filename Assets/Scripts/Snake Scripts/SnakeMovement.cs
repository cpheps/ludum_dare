using UnityEngine;
using System.Collections;

public class SnakeMovement : MonoBehaviour {

	[SerializeField]
	private int snakeSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);
	}
}

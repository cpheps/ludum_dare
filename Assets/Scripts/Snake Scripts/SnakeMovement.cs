using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour {

	[SerializeField]
	private int snakeSpeed = 5;

	private List<Transform> snakeSegments = new List<Transform>();

	private Transform snakeHead = null;

	// Use this for initialization
	void Start () 
	{
		snakeHead = transform.Find("Head");
	}

	// Update is called once per frame
	void Update () {
		snakeHead.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);

	}
}

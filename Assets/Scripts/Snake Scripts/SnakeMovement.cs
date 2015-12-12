using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour {

	#region Public
	/// <summary>
	/// Adds a new segement behind the last snake segment
	/// </summary>
	public void addSegment()
	{
		Transform lastSegment = snakeSegments.Count == 0 ? snakeHead : snakeSegments[snakeSegments.Count -1];
		GameObject newSegment = GameObject.Instantiate(snakeSegment) as GameObject;

		//Child new segment under snake
		newSegment.transform.SetParent(transform);

		//Set new segment position
		newSegment.transform.localPosition = lastSegment.localPosition - new Vector3(0, 0, 1);
		newSegment.transform.localRotation = lastSegment.localRotation;

		snakeSegments.Add(newSegment.transform);
	}
	#endregion

	#region Private
	[SerializeField]
	private int snakeSpeed = 5;

	//Used to instantiate new snake segments
	[SerializeField]
	private GameObject snakeSegment = null;

	private List<Transform> snakeSegments = new List<Transform>();

	private Transform snakeHead = null;

	// Use this for initialization
	void Start () 
	{
		snakeHead = transform.Find("Head");
		InvokeRepeating("growSnake", 1, 1);
	}

	// Update is called once per frame
	void Update () 
	{

		//Used to move the next segment to the spot of the one ahead
		Vector3 nextPosition = snakeHead.transform.localPosition;

		snakeHead.Translate(Vector3.forward * snakeSpeed * Time.deltaTime);

		for (int segmentIndex = 0; segmentIndex < snakeSegments.Count; ++segmentIndex)
		{
			Transform snakeSegment = snakeSegments[segmentIndex];

			Vector3 lastSegmentPosition = snakeSegment.localPosition;

			snakeSegment.localPosition = nextPosition - new Vector3(0, 0, 1);

			nextPosition = lastSegmentPosition;
		}
	}

	/// <summary>
	/// Grows the snake.
	/// </summary>
	private void growSnake()
	{
		addSegment();
	}
	#endregion
}

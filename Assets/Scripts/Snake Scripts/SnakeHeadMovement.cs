using UnityEngine;
using System.Collections;

public class SnakeHeadMovement : MonoBehaviour {

	[SerializeField]
	private int snakeSpeed = 7;

	private bool coilLeft = false;
	private bool coilRight = false;

	public bool CoilLeft
	{
		set 
		{
			coilLeft = value;
		}
	}

	public bool CoilRight
	{
		set
		{
			coilRight = value;
		}
	}


	// Update is called once per frame
	void Update () {
		if (coilLeft) {
			transform.rotation = Quaternion.Lerp (transform.rotation, transform.rotation*Quaternion.Euler (0, 0, 30), Time.deltaTime * 5);
		}
		else if(coilRight)
		{
			transform.rotation = Quaternion.Lerp (transform.rotation, transform.rotation*Quaternion.Euler (0, 0, -30), Time.deltaTime * 5);
		}

		transform.Translate(new Vector3(1,0,0) * snakeSpeed * Time.deltaTime);
	}

	public void Grow()
	{
		foreach(Transform child in transform)
		{
			SegmentMovement segmentMovement = child.GetComponent<SegmentMovement>();
			segmentMovement.Grow();
		}
	}
}

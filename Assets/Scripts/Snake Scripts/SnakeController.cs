using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {
	private Color32 playerColor = Color.black;
	private List<GameObject> segments = new List<GameObject>();
	public GameObject segment;
	public bool playerControlled = true;
	public bool turnRight = false;
	public bool turnLeft = false;

	public void gameStart()
	{
		InvokeRepeating ("Move", .020f, .020f);
	}

	public Color32 PlayerColor
	{
		set
		{
			playerColor = value;
			for (int segmentIndex = 0; segmentIndex < segments.Count; ++segmentIndex)
			{
				segments[segmentIndex].GetComponent<Renderer>().material.color = playerColor;
			}
		}
	}

	void Start () {
		GameObject head = transform.Find("Head").gameObject;

		head.GetComponent<Renderer>().material.color = playerColor;

		segments.Add (head);

//		InvokeRepeating ("AddSegment", 1, 1);
	}

	void Update () {
		if (playerControlled) {
			turnRight = Input.GetKey (KeyCode.S);
			turnLeft = Input.GetKey (KeyCode.A);
		}
	}

	void Move() {
		for(int i = segments.Count; i > 1; --i)
		{
			segments[i-1].transform.localPosition = segments[i-2].transform.localPosition;
			segments[i-1].transform.rotation = segments[i-2].transform.rotation;
		}
		segments[0].transform.Translate(new Vector3(10,0,0) * 1 * Time.deltaTime);
		if (turnLeft) {
			segments [0].transform.localRotation *= Quaternion.Euler(Vector3.forward * 5);
		} else if (turnRight) {
			segments [0].transform.localRotation *= Quaternion.Euler (Vector3.forward * -5);
		}
	}

	public void AddSegment(){
		GameObject predecessor = segments [segments.Count - 1];
		GameObject g = (GameObject)GameObject.Instantiate (segment, new Vector3(-50, -50, -50), transform.rotation);
		g.GetComponent<Renderer>().material.color = playerColor;
		g.transform.parent = this.transform;
		g.transform.localPosition = predecessor.transform.localPosition + new Vector3 (-1f, 0, 0);
		g.name = "Segment";
		segments.Add (g);
	}
}

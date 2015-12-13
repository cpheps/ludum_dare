using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {
	private List<GameObject> segments = new List<GameObject>();
	public GameObject segment;
	public bool playerControlled = true;
	public bool turnRight = false;
	public bool turnLeft = false;
		
	void Start () {
		segments.Add (transform.Find("Head").gameObject);
		InvokeRepeating ("Move", .020f, .020f);
		InvokeRepeating ("AddSegment", 1, 1);
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
			segments[i-1].transform.position = segments[i-2].transform.position;
			segments[i-1].transform.rotation = segments[i-2].transform.rotation;
		}
		segments[0].transform.Translate(Vector3.forward * 7 * Time.deltaTime);
		if (turnLeft) {
			segments [0].transform.localRotation *= Quaternion.Euler(Vector3.up * 5);
		} else if (turnRight) {
			segments [0].transform.localRotation *= Quaternion.Euler (Vector3.up * -5);
		}
	}

	public void AddSegment(){
		GameObject predecessor = segments [segments.Count - 1];
		GameObject g = (GameObject)GameObject.Instantiate (segment, new Vector3(-50, -50, -50), transform.rotation);
		g.transform.parent = this.transform;
		g.transform.localPosition += new Vector3 (-0.5f, 0, 0);
		g.name = "Segment";
		segments.Add (g);
	}
}

using UnityEngine;
using System.Collections;

public class TimedBehavior : MonoBehaviour {
	private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > 5) {
			elapsedTime = 0;
			foreach (GameObject o in GameObject.FindGameObjectsWithTag ("Snake Segment")) {
				o.SendMessage ("Grow");
			}
		}
	}
}

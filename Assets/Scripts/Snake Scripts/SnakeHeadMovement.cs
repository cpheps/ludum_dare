using UnityEngine;
using System.Collections;

public class SnakeHeadMovement : MonoBehaviour {

	[SerializeField]
	private int snakeSpeed = 7;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.rotation = Quaternion.Lerp (transform.rotation, transform.rotation*Quaternion.Euler (0, 0, 30), Time.deltaTime * 5);
		}

		transform.Translate(new Vector3(1,0,0) * snakeSpeed * Time.deltaTime);
	}
}

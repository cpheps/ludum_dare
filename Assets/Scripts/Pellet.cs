using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Snake Head")
		{
			SnakeHeadMovement snakeHeadMovement = collider.transform.GetComponent<SnakeHeadMovement>();
			snakeHeadMovement.Grow();
			Destroy(gameObject);
		}
	}
}

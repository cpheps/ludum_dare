using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Snake Head")
		{
			collider.transform.SendMessageUpwards("AddSegment");
			Destroy(gameObject);
			//add a point to the player that collides with the pellet
			print (collider.transform.parent.gameObject.name.ToString());
			ScoreKeeper.Instance.increaseScore(collider.transform.parent.gameObject.name.ToString(), 1);
		}
	}
}

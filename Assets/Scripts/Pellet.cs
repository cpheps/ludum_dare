using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Snake Head")
		{
			collider.transform.SendMessageUpwards("AddSegment");
			Destroy(gameObject);
			//TODO when we have multiple players, pass correct player as first var
			ScoreKeeper.Instance.increaseScore(1,1);
		}
	}
}

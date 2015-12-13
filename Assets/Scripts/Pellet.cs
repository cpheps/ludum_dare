using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Snake Head")
		{
			collider.transform.SendMessageUpwards("AddSegment");
			Destroy(gameObject);
		}
	}
}

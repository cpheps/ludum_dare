using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.name);
		if (collider.tag == "Snake Head")
		{
			collider.transform.SendMessageUpwards("addSegment");
			Destroy(gameObject);
		}
	}
}

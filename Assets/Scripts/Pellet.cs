using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		collider.transform.SendMessageUpwards("addSegment");
		Destroy(gameObject);
	}
}

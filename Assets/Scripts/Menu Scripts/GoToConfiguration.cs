using UnityEngine;
using System.Collections;

public class GoToConfiguration : MonoBehaviour {

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("Configuration");
		}
	}
}

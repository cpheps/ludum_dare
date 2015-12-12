using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			Application.Quit ();	
		}
	}
}

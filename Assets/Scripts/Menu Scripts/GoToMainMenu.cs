using UnityEngine;
using System.Collections;

public class GoToMainMenu : MonoBehaviour {
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("MainMenu");
		}
	}
}

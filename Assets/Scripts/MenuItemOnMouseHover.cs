using UnityEngine;
using System.Collections;

public class MenuItemOnMouseHover : MonoBehaviour {

	private GUIText menuItemText;

	void OnMouseOver() {
		this.GetComponentInChildren<TextMesh> ().color = Color.red;
	}

	void OnMouseExit() {
		this.GetComponentInChildren<TextMesh> ().color = Color.white;
	}
}
